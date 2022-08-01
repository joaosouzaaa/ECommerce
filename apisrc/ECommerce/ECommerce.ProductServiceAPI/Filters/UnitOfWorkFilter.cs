using ECommerce.ProductServiceAPI.Domain.Interface;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerce.ProductServiceAPI.Filters;

public class UnitOfWorkFilter : ActionFilterAttribute
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationHandler _notification;

    public UnitOfWorkFilter(IUnitOfWork unitOfWork, INotificationHandler notification)
    {
        _unitOfWork = unitOfWork;
        _notification = notification;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (ExternalMethodFilter.IsMethodGet(context))
        {
            return;
        }

        if (context.Exception == null && context.ModelState.IsValid && !this._notification.HasNotification())
        {
            this._unitOfWork.Commit();
        }
        else
        {
            this._unitOfWork.Rollback();
        }
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (ExternalMethodFilter.IsMethodGet(context))
        {
            return;
        }

        this._unitOfWork.BeginTransaction();
    }

}
