using FluentValidation;
using FluentValidation.Results;
using product_stock_mvc.Business.Interfaces;
using product_stock_mvc.Business.Models;

namespace product_stock_mvc.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotifier _notifier;

        public BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }
        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notifications.Notification(message));
        }

        protected bool ExecuteValidation<TValidation, TEntity> (TValidation validation, 
                                                                TEntity entity) 
                                                                where TValidation : AbstractValidator<TEntity>
                                                                where TEntity : BaseEntity
        {
            var validator = validation.Validate(entity);
            if (validator.IsValid) return true;

            Notify(validator);
            return false;
        }
    }
}
