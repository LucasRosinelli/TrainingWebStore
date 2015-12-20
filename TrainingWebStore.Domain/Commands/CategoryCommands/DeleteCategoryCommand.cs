namespace TrainingWebStore.Domain.Commands.CategoryCommands
{
    public class DeleteCategoryCommand
    {
        public DeleteCategoryCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}