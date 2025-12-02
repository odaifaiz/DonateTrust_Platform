using System.Numerics;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

public class BlockchainDonationsService
{
    private readonly Web3 _web3;
    private readonly string _contractAddress;
    private readonly Nethereum.Contracts.Contract _contract;

    // 📌 عدّلها لاحقًا: عنوان الـ RPC (شبكة Hardhat local)
    private const string RpcUrl = "http://127.0.0.1:8545";

    // 📌 عدّلها: Private key لأحد الحسابات اللي طلعها لك npx hardhat node
    private const string PrivateKey = "0xضع_هنا_private_key";

    // 📌 عدّلها: عنوان العقد اللي طلع من hardhat run scripts/deploy.ts --network localhost
    private const string ContractAddress = "0xضع_هنا_عنوان_العقد";

    // 📌 هنا تحط ABI اللي داخل Donations.json (قيمة الـ "abi": [ ... ])
    private const string Abi = @"[ ضع JSON الـ ABI كامل هنا ]";

    public BlockchainDonationsService()
    {
        var account = new Account(PrivateKey);
        _web3 = new Web3(account, RpcUrl);
        _contractAddress = ContractAddress;
        _contract = _web3.Eth.GetContract(Abi, _contractAddress);
    }

    // 🔹 1) إرسال تبرع (amount بالـ ETH)
    public async Task<string> SendDonationAsync(decimal amountEth, string note)
    {
        var donateFunction = _contract.GetFunction("donate");

        BigInteger amountWei = Web3.Convert.ToWei(amountEth);

        // نرسل الترانزكشن مع قيمة ETH + note
        var txHash = await donateFunction.SendTransactionAsync(
            from: (await _web3.Eth.CoinBase.SendRequestAsync()),
            gas: new BigInteger(300000),
            value: amountWei,
            functionInput: note
        );

        return txHash; // تقدر تخزنه في قاعدة بيانات التبرعات
    }

    // 🔹 2) قراءة إجمالي تبرعات متبرع معيّن بالـ ETH
    public async Task<decimal> GetDonorTotalAsync(string donorAddress)
    {
        var func = _contract.GetFunction("getDonorTotal");
        var resultWei = await func.CallAsync<BigInteger>(donorAddress);
        return Web3.Convert.FromWei(resultWei);
    }

    // 🔹 3) قراءة بيانات تبرع واحد
    public async Task<DonationDto> GetDonationAsync(uint id)
    {
        var func = _contract.GetFunction("getDonation");
        var result = await func.CallDeserializingToObjectAsync<DonationOutputDTO>(id);

        return new DonationDto
        {
            Id = (uint)result.Id,
            Donor = result.Donor,
            AmountEth = Web3.Convert.FromWei(result.Amount),
            Timestamp = (long)result.Timestamp,
            Note = result.Note
        };
    }
}

// DTO لنتائج getDonation
public class DonationOutputDTO
{
    [Nethereum.ABI.FunctionEncoding.Attributes.Parameter("uint256", "0", 1)]
    public BigInteger Id { get; set; }

    [Nethereum.ABI.FunctionEncoding.Attributes.Parameter("address", "1", 2)]
    public string Donor { get; set; }

    [Nethereum.ABI.FunctionEncoding.Attributes.Parameter("uint256", "2", 3)]
    public BigInteger Amount { get; set; }

    [Nethereum.ABI.FunctionEncoding.Attributes.Parameter("uint256", "3", 4)]
    public BigInteger Timestamp { get; set; }

    [Nethereum.ABI.FunctionEncoding.Attributes.Parameter("string", "4", 5)]
    public string Note { get; set; }
}

// نموذج بسيط نستعمله في الواجهة
public class DonationDto
{
    public uint Id { get; set; }
    public string Donor { get; set; }
    public decimal AmountEth { get; set; }
    public long Timestamp { get; set; }
    public string Note { get; set; }
}
