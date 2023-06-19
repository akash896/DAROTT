namespace ott3.Models
{
    public class CommonResponse
    {
        public bool isSuccess { get; set; }
        public dynamic data { get; set; }
        public dynamic extradata { get; set; }
        public string msg { get; set; }

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

        public CommonResponse() {
            this.isSuccess = false;
            this.msg = "error occured";
        }
    }
}