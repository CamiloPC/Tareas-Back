namespace TaskApi.Infrastructure.Services.Extensions
{
    public static class EncoderDecoderHelper
    {
        public static string EncodePasswordToBase64(this string pass)
        {
            try
            {
                byte[] encData_byte = new byte[pass.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(pass);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public static string DecodeFromBase64(this string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] to_decode = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(to_decode, 0, to_decode.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(to_decode, 0, to_decode.Length, decoded_char, 0);
            string res = new string(decoded_char);

            return res;
        }

    }
}
