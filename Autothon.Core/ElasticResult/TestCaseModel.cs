namespace Autothon.Core.ElasticResult
{
    public class TestCaseModel
    {
       
        private string testClass;

       
        private string description;

       
        private string status;

       
        private string executionTime;

        public void setDescription(string description)
        {
            this.description = description;
        }

        public void setExecutionDate(string executionTime)
        {
            this.executionTime = executionTime;
        }

        public void setStatus(string status)
        {
            this.status = status;
        }

        public void setTestClass(string testClass)
        {
            this.testClass = testClass;
        }

    }
}
