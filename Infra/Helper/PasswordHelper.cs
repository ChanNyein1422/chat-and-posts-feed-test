namespace Infra.Helper
{
    public class PasswordHelper
    {
        public static string EncryptPassword(string password)
        {
            try
            {
                byte[] encryptDataByte = new byte[password.Length];
                encryptDataByte = System.Text.Encoding.UTF8.GetBytes(password);
                string encryptedData = Convert.ToBase64String(encryptDataByte);
                return encryptedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public static string DecryptPassword(string password)
        {
            System.Text.UTF8Encoding decrypt = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = decrypt.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(password);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}
