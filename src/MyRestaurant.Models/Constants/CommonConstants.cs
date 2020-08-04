namespace MyRestaurant.Models.Constants
{
    public class CommonConstants
    {
        public const string RestaurantRole = "Restaurant";
        public const string SystemAdmin = "SystemAdmin";
        public const string User = "User";
        public const string Administrator = "Administrator";
        public const string FBTokenVerificationUrl = "https://graph.facebook.com/me?access_token={0}";
        public const string GTokenVerificationUrl = "https://www.googleapis.com/oauth2/v1/tokeninfo?access_token={0}";
        public const string TTokenVerificationUrl = "https://api.twitter.com/1.1/account/verify_credentials.json";
        public const string GClientId = "853380340681-arcdbeog87iqqvl910locftgqjdbcfst.apps.googleusercontent.com";
        public const string GClientSecret = "GEh-elT6mGEVGsJe9JAdcTIE";
        public const string RestaurantLogoKey = "RestaurantLogoUrl";
        public const string MenuLogoKey = "MenuLogoUrl";
        public const string RestaurantUrlKey = "RestaurantUrl";
        public const string UIUrlKey = "UIUrl";
        public const string OfferImageUrlKey = "OfferImageUrl";
        public const string ChefImageUrlKey = "ChefImageUrl";
        public class SuccessCode
        {
            public const string MenuDeleted = "113";
            public const string UserSaved = "101";
            public const string MenuItemDeleted = "114";
            public const string MenuItemSaved = "115";
            public const string MenuItemUpdated = "116";
            public const string MenuSaved = "117";
            public const string MenuUpdated = "118";
            public const string RestaurantSaved = "119";
            public const string RestaurantUpdated = "120";
            public const string RestaurantDelete = "121";
            public const string FileUploaded = "122";
            public const string CitySaved = "123";
            public const string NavigationSaved = "124";
            public const string NavigationUpdated = "125";
            public const string NavigationDeleted = "126";
            public const string MessageSaved = "127";
            public const string MessageUpdated = "128";
            public const string OfferSaved = "129";
            public const string OfferDeleted = "130";
            public const string AllOfferDeleted = "131";
            public const string OfferUpdated = "132";
            public const string ChefSaved = "133";
            public const string ChefUpdated = "134";
            public const string ChefDeleted = "135";
            public const string AllChefDeleted = "136";
        }
        public class ErrorCode
        {
            public const string InternalServerError = "500";
            public const string InvalidModel = "102";
            public const string UserExists = "101";
            public const string InvalidId = "105";
        }
    }
}
