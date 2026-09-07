namespace Ecom.Core.Sharing
{
    public class EmailStringBody
    {
        public static string send(string email, string token, string component, string message)
        {
            string encodeToken = Uri.EscapeDataString(token);
            string encodeEmail = Uri.EscapeDataString(email);

            return $@"
            <html> 
                <head>
                    <style>
                        .button {{
                            border: none;
                            border-radius: 10px;
                            padding: 15px 30px;
                            color: #fff !important;
                            display: inline-block;
                            background: linear-gradient(45deg, #ff7e5f, #feb47b);
                            cursor: pointer;
                            text-decoration: none;
                            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.2);
                            font-size: 16px;
                            font-weight: bold;
                            font-family: 'Arial', sans-serif;
                        }}
                    </style>
                </head>
                <body>
                    <h1>{message}</h1>
                    <hr>
                    <br>
                    <a class=""button"" href=""https://localhost:7093/api/Account/active-account?email={{encodeEmail}}&code={{encodeToken}}"">
                        Confirm Email
                    </a>
                </body>
            </html>";
        }
    }
}