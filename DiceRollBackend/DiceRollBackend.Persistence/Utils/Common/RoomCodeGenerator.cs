using System.Security.Cryptography;
using System.Text;
using DiceRollBackend.Domain.Interfaces.Common;

namespace DiceRollBackend.Persistence.Utils.Common;

public class RoomCodeGenerator : IRoomCodeGenerator
{
    
    public string GenerateRoomCode()
    {
        var dateTimeStr = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(dateTimeStr));

        var sb = new StringBuilder();
        for (var i = 0; sb.Length < 6 && i < hash.Length; i++)
        {
            var value = hash[i] % 36;
            var c = (char)(value < 10 ? '0' + value : 'A' + (value - 10));
            sb.Append(c);
        }

        return sb.ToString();
    }

}