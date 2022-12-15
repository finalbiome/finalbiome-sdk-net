using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using System.Threading.Tasks;
using Firebase.Auth.Repository;
using Firebase.Auth;

namespace FinalBiome.Sdk;

/// <summary>
/// Persistence of the user auth session data.
/// </summary>
/// <inheritdoc />
public class FileUserRepository : IUserRepository
{
    public const string UserFileName = "finalbiome_auth.json";

    private readonly string filename;
    private readonly JsonSerializerSettings options;

    /// <summary>
    /// Creates new instance of <see cref="FileUserRepository"/>.
    /// </summary>
    /// <param name="folder"> Name of the subfolder to be created / accessed under <see cref="Environment.SpecialFolder.ApplicationData"/>. </param>
    public FileUserRepository(string folder)
    {
        this.filename = Path.Combine(folder, UserFileName);
        this.options = new JsonSerializerSettings();
        this.options.Converters.Add(new StringEnumConverter());

        Directory.CreateDirectory(folder);
    }

    public virtual Task<(UserInfo, FirebaseCredential)> ReadUserAsync()
    {
        var content = File.ReadAllText(this.filename);
        var obj = JsonConvert.DeserializeObject<UserDal>(content, this.options);
        return Task.FromResult((obj!.UserInfo, obj.Credential));
    }

    public virtual Task SaveUserAsync(User user)
    {
        var content = JsonConvert.SerializeObject(new UserDal(user.Info, user.Credential), this.options);
        File.WriteAllText(this.filename, content);
        return Task.CompletedTask;
    }

    public virtual Task DeleteUserAsync()
    {
        File.Delete(this.filename);
        return Task.CompletedTask;
    }

    public Task<bool> UserExistsAsync()
    {
        return Task.FromResult(File.Exists(this.filename));
    }

    internal class UserDal
    {
#pragma warning disable CS8618
        public UserDal() {}
#pragma warning restore CS8618

        public UserDal(UserInfo userInfo, FirebaseCredential credential)
        {
            this.UserInfo = userInfo;
            this.Credential = credential;
        }

        public UserInfo UserInfo { get; set; }

        public FirebaseCredential Credential { get; set; }
    }
}
