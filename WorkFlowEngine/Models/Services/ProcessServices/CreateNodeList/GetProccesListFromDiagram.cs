using Database.Models;
using System.Text.Json;
using WorkFlowEngine.Models.DeSerialization;
using WorkFlowEngine.Models.DTOs.ProccesDigram;
using Newtonsoft.Json;

namespace WorkFlowEngine.Models.Services.ProcessServices.CreateNodeList
{
    public class GetProccesListFromDiagram
    {
        public Guid startNodeGuid { get; set; }
        public List<ProcessSecrviceDTO> Nodelist { get; set; }
        public GetProccesListFromDiagram(string diagramJson)
        {
            dynamic diagramJsonObje2ct = JsonConvert.DeserializeObject(diagramJson);
            DiagramJsonObject diagramJsonObject = JsonConvert.DeserializeObject<DiagramJsonObject>(diagramJson);


            //Map all Node ids with new GUID
            List<GUID_Mapper> GUIDmapper = new List<GUID_Mapper>();
            foreach (var node in diagramJsonObject.nodes)
                GUIDmapper.Add(new GUID_Mapper { nodeId = node.id , GUID = Guid.NewGuid()});

            //Index all nodes in diagram
            foreach (var node in diagramJsonObject.nodes)
            {
                string[] targetIds = new string[] { Guid.Empty.ToString(),Guid.Empty.ToString()} ;
                int counter = 0;
                foreach (var connector in diagramJsonObject.connectors)
                {
                    string sourceId = connector.sourceID;
                    string targetId = connector.targetID;
                    if (sourceId == node.id)
                    {
                        targetIds[counter] = targetId;
                        counter++;
                    }
                }
                Nodelist.Add(new ProcessSecrviceDTO()
                {
                    processId = GUIDmapper.FirstOrDefault(x => x.nodeId == node.id).GUID,
                    formId = GUIDmapper.FirstOrDefault(x => x.nodeId == node.addInfo.FormId).GUID,
                    Message = node.addInfo.Message,
                    outhUser = { node.addInfo.OuthUser },
                    nextProcessIdNo1 = GUIDmapper.FirstOrDefault(x => x.nodeId == targetIds[0]).GUID,
                    nextProcessIdNo2 = GUIDmapper.FirstOrDefault(x => x.nodeId == targetIds[1]).GUID,
                });
            }

            //Get First Node
            foreach (var connector in diagramJsonObject.connectors)
            {
                string sourceId = connector.sourceID;
                if (sourceId.Contains("SequentialData"))
                {
                    Guid GUIDSourceId = GUIDmapper.FirstOrDefault(x => x.nodeId == sourceId).GUID;
                    startNodeGuid = GUIDSourceId;
                    break;
                }
            }
        }
    }
}
