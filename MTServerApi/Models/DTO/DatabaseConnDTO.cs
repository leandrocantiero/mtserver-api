using System.ComponentModel.DataAnnotations;

namespace mtvendors_api.Models.DTO
{
    public class DatabaseConnDTO
    {
        public DatabaseConnDTO(string connectionString)
        {
            //server=localhost;user=root;password=password;database=fal

            if (!string.IsNullOrEmpty(connectionString))
            {
                var splited = connectionString.Split(';');

                Host = splited[0].Split('=')[1];
                User = splited[1].Split('=')[1];
                Password = splited[2].Split('=')[1];
                DatabaseName = splited[3].Split('=')[1];
            }
        }

        [Required(ErrorMessage = "O campo Host é obrigatório")]
        public string? Host { get; set; }

        [Required(ErrorMessage = "O campo User é obrigatório")]
        public string? User { get; set; }

        public string? Password { get; set; }

        [Required(ErrorMessage = "O campo DatabaseName é obrigatório")]
        public string? DatabaseName { get; set; }

        public string ConnectionString => "server=" + Host + ";user=" + User + ";password=" + Password + ";database=" + DatabaseName;
    }
}
