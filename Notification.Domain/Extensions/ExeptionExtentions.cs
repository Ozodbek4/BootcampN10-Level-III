using Notification.Domain.Common.Extentions;

namespace Notification.Domain.Extensions;

public static class ExeptionExtentions
{
    public static async ValueTask<FuncResult<T>> GetValueAsyc<T>(this Func<Task<T>> func) where T : struct
    {
        FuncResult<T> result;

        try
        {
            result = new FuncResult<T>(await func());
        }
        catch(Exception ex)
        {
            result = new FuncResult<T>(ex);
        }

        return result;
    }

    public static async ValueTask<FuncResult<T>> GetValueAsyc<T>(this Func<ValueTask<T>> func) where T : struct
    {
        FuncResult<T> result;

        try
        {
            result = new FuncResult<T>(await func());
        }
        catch (Exception ex)
        {
            result = new FuncResult<T>(ex);
        }

        return result;
    }
}