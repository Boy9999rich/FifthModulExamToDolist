using FluentValidation;
using ToDolist.Bll.Validators;

namespace ToDoList.Configurations
{
    public static class FluentValidationDependencyInjection
    {
        public static void AddFluentValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<ToDoItemCreateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<toDoItemUpdateDtoValidator>();
        }
    }
}
