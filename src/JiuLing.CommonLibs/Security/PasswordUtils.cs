#if NET6_0_OR_GREATER
using System;
using System.Security.Cryptography;

namespace JiuLing.CommonLibs.Security;

/// <summary>
/// 密码工具
/// </summary>
public static class PasswordUtils
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 100_000;

    /// <summary>
    /// 对密码进行哈希
    /// </summary>
    /// <param name="password">密码</param>
    /// <returns></returns>
    public static string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            HashSize
        );

        byte[] result = new byte[SaltSize + HashSize];
        Buffer.BlockCopy(salt, 0, result, 0, SaltSize);
        Buffer.BlockCopy(hash, 0, result, SaltSize, HashSize);

        return Convert.ToBase64String(result);
    }

    /// <summary>
    /// 验证密码是否正确
    /// </summary>
    /// <param name="password">密码</param>
    /// <param name="storedHash">密码的哈希值</param>
    /// <returns></returns>
    public static bool VerifyPassword(string password, string storedHash)
    {
        try
        {
            byte[] bytes = Convert.FromBase64String(storedHash);

            byte[] salt = bytes[..SaltSize];
            byte[] expectedHash = bytes[SaltSize..];

            byte[] actualHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256,
                HashSize
            );

            return CryptographicOperations.FixedTimeEquals(expectedHash, actualHash);
        }
        catch (Exception)
        {
            return false;
        }
    }
}

#endif
