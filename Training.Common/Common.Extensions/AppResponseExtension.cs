using System.Runtime.CompilerServices;
using Training.Common.Common.Enum;
using Training.Common.DTO;

namespace Training.Common.Common.Extensions
{
    public static class AppResponseExtension
    {

        public static AppResponse ReturnError(this AppResponse source, string error, string status, int Id)
        {

            source.Fail.ErrorMessage = error;
            source.Fail.Status = status;
            source.Fail.Id = Id;
            return source;
        }
        public static AppResponse SetFail(this AppResponse source, string error)
        {

            source.Fail.ErrorMessage = error;
            source.Fail.Status = nameof(AppResponseEnums.SaveFail);
            source.Fail.Id = (int)AppResponseEnums.SaveFail; return source;

        }
        public static AppResponse SetSaveSuccess(this AppResponse source, string msg)
        {

            source.Success.Message = msg;
            source.Success.Status = nameof(AppResponseEnums.SaveSuccess);
            source.Success.Id = (int)AppResponseEnums.SaveSuccess; return source;

        }
        public static AppResponse SetUpdateSuccess(this AppResponse source, string msg)
        {

            source.Success.Message = msg;
            source.Success.Status = nameof(AppResponseEnums.UpdateSuccess);
            source.Success.Id = (int)AppResponseEnums.UpdateSuccess; return source;

        }
        public static AppResponse SetUpdateFail(this AppResponse source, string error)
        {

            source.Fail.ErrorMessage = error;
            source.Fail.Status = nameof(AppResponseEnums.UpdateFail);
            source.Fail.Id = (int)AppResponseEnums.UpdateFail; return source;

        }
    }
}
