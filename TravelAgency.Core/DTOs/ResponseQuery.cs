using System.Collections.Generic;

namespace TravelAgency.Core.DTOs.Response
{
    public class ResponseQuery<T>
    {
        public ResponseQuery()
        {
            this.Successful = true;
        }
        /// <summary>
        /// True: indicates that the operation was executed successfully.
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// Fault code in case of an error.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Detail of the error that may occur.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Fault code in case of an error.
        /// </summary>
        public List<string> ListMessage { get; set; }

        /// <summary>
        /// Composite entity with information
        /// </summary>
        public T Result { get; set; }

        public void ResponseMessage(string message, bool successfull, string errorMessage = "")
        {
            this.Message = message;
            this.Successful = successfull;
            this.ErrorMessage = errorMessage;
        }
        public void RequirementErrorMessage(List<string> ListMessage)
        {
            this.Message = "requirement Error";
            this.Successful = false;
            this.ListMessage = ListMessage;
        }
    }
}
