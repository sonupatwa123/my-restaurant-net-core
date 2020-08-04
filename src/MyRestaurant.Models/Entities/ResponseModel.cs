using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
    [NotMapped]
    public class ResponseModel<T> where T:class
    {
        private string successCode;
        public bool IsFailed { get; set; }
        public string ErrorCode { get; set; }
        public bool IsSuccess { get; set; }
        public string SuccessCode { get {
                return successCode;
            } set {                
                successCode = value;
            } }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public T ResponseObject { get; set; } 
    }
}
