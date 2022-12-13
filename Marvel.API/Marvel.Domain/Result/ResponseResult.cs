using System.Net;
using Marvel.Domain.Enums;
using Marvel.Domain.Util;

namespace Marvel.Domain.Result
{
    public class ResponseResult<TEntity>
    {
        public ResponseResult()
        {
            Exception = new ExceptionResponse();
            Message = GetMessage();
        }      

        private InternalCode internalCode;
        public InternalCode InternalCode
        {
            get
            {
                return internalCode;
            }

            set
            {
                internalCode = value;
                Message = GetMessage();
            }
        }
        public ExceptionResponse Exception { get; set; }
        public string Message { get; set; }

        public TEntity Data { get; set; }

        public ResponseResult<TEntity> CreateResponse(Exception exception, InternalCode internalCode)
        {
            this.Exception.StackTrace = exception.StackTrace;
            this.Exception.InnerExceptions = exception.GetInnerExceptions();
            this.internalCode = internalCode;
            this.Message = this.GetMessage();
            return this;
        }

        private string GetMessage()
        {
            string message = internalCode switch
            {
                InternalCode.Success => Constants.SUCCESS,
                InternalCode.HeroSameSide => Constants.HEROSAMESIDE,
                InternalCode.NotFound => Constants.NOTFOUND,
                InternalCode.InternalError => Constants.INTERNALERROR,
                _ => Constants.SUCCESS,
            };
            return message;
        }
    }
}
