using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main.Front
{
    public class Question : EntityBase, IEntity
    {
        public string AzQuestionTitle { get; set; }
        public string EnQuestionTitle { get; set; }
        public string RuQuestionTitle { get; set; }

        public string AzQuestionAnswer { get; set; }
        public string EnQuestionAnswer { get; set; }
        public string RuQuestionAnswer { get; set; }
    }
}
