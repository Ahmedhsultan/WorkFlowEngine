using Database.Models;
using System.Diagnostics;
using System.Text.Json;
using WorkFlowEngine.Models.DeSerialization;

namespace WorkFlowEngine.Models.Services
{
    public class ProcessServices
    {
        public void CreateProcessFromDiagramJson(string diagramJson , Digrams diagram)
        {
           /* DiagramJsonObject? diagramJsonObject = JsonSerializer.Deserialize<DiagramJsonObject>(diagramJson);

            List<Process> processesList = new List<Process>();

            foreach (var item in collection)
            {
                processesList.Add(new Processes()
                {
                    processId = new Guid(process.processId),
                    digram = diagram,
                    formId = new Guid(process.form),
                    outhUser = outhUserList,
                    nextProcessIdNo1 = new Guid(process.nextProcessIdNo1),
                    nextProcessIdNo2 = new Guid(process.nextProcessIdNo2),
                });
            }*/
        }
    }
}
