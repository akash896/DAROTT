namespace ott3.Models
{
    public class CommonResponse
    {
        public bool isSuccess { get; set; }
        public dynamic data { get; set; }
        public dynamic extradata { get; set; }
        public string msg { get; set; }

        public CommonResponse() { 
            this.isSuccess = false;
            this.extradata = "";
            this.msg = "";
            this.data = null;
        }
        public CommonResponse(bool isSuccess, string msg, dynamic data)
        {
            this.isSuccess = isSuccess;
            this.data = data;
            this.extradata = "";
            this.msg = msg;
        }
        public CommonResponse(bool isSuccess, string msg, dynamic data, dynamic extradata)
        {
            this.isSuccess = isSuccess;
            this.data = data;
            this.extradata = extradata;
            this.msg = msg;
        }
    }

    public class Utility
    {
        public static int getUserId()
        {
            return 1;
        }
        public static string getUserName()
        {
            return "userName123";
        }
    }
}