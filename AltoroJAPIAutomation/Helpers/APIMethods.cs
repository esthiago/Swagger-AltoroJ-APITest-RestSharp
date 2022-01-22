namespace AltoroJAPIAutomation.Helpers
{
    class APIMethods
    {
        //GROUP LOGIN: GET Login, POST Login 
        public static string Get_Login
        {
            get
            {
                return $"{CustomConfigurationProvider.GetKey("AltoroJService-baseUrl")}" + "login";
            }
        }

        //GROUP ACCOUNT: Get Account, Get Account By ID, GET transactions by id, Post transactions by id and date
        public static string Get_Account
        {
            get
            {
                return $"{CustomConfigurationProvider.GetKey("AltoroJService-baseUrl")}" + "account";
            }
        }

        //GROUP TRANSFER: POST Transfer
        public static string Post_Transfer
        {
            get
            {
                return $"{CustomConfigurationProvider.GetKey("AltoroJService-baseUrl")}" + "transfer";
            }
        }

        //GROUP FEEDBACK: POST Feedback
        public static string Post_Feedback
        {
            get
            {
                return $"{CustomConfigurationProvider.GetKey("AltoroJService-baseUrl")}" + "feedback";
            }
        }

        //GROUP ADMIN: POST New User
        public static string Post_Admin
        {
            get
            {
                return $"{CustomConfigurationProvider.GetKey("AltoroJService-baseUrl")}" +"admin";
            }
        }

        //GROUP LOGOUT: GET Logout
        public static string Get_Logout
        {
            get
            {
                return $"{CustomConfigurationProvider.GetKey("AltoroJService-baseUrl")}" + "logout";
            }
        }
    }
}
