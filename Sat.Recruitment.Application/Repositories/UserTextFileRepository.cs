using System.Globalization;
using Sat.Recruitment.Application.Repositories.Interfaces;
using Sat.Recruitment.Application.Repositories.Dtos;

namespace Sat.Recruitment.Application.Repositories;

public class UserTextFileRepository : IUserRepository
{
    private const string UserFilePath = "/Files/Users.txt";

    public async Task<List<UserDto>> GetAll()
    {
        var users = new List<UserDto>();

        using (var reader = new StreamReader(Directory.GetCurrentDirectory() + UserFilePath))

        {
            while (true)
            {
                var line = await reader.ReadLineAsync();

                if (line != null)
                {
                    line = line.Replace("\"", "");
                    var lineSplit = line.Split(',');

                    if (lineSplit.Length > 0)
                        users.Add(new UserDto(lineSplit[0],
                            lineSplit[1],
                            lineSplit[2],
                            lineSplit[3],
                            lineSplit[4],
                            Convert.ToDecimal(lineSplit[5]),
                            Convert.ToDecimal(lineSplit[6])));
                }
                else
                {
                    break;
                }
            }

            return users;
        }
    }

    public async Task SaveUser(UserDto userDto)
    {
        if (userDto == null)
            throw new InvalidDataException();

        var user = new List<string>
        {
            userDto.Name,
            userDto.Email,
            userDto.Phone,
            userDto.Address,
            userDto.UserType,
            userDto.OriginalMoney.ToString(CultureInfo.InvariantCulture),
            userDto.GiftedAmount.ToString(CultureInfo.InvariantCulture)
        };

        var userString = string.Join(",", user);

        await using StreamWriter file = new(Directory.GetCurrentDirectory() + UserFilePath, true);
        await file.WriteLineAsync(userString);
    }
}