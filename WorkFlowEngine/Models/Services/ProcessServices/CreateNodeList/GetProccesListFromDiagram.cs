using Newtonsoft.Json;
using WorkFlowEngine.Models.DeSerialization;

namespace WorkFlowEngine.Models.Services.ProcessServices.CreateNodeList
{
    public class GetProccesListFromDiagram
    {
        public Guid startNodeGuid { get; set; }
        public List<ProcessSecrviceDTO> Nodelist { get; set; }
        public GetProccesListFromDiagram(string diagramJson)
        {
            //dynamic diagramJsonObje2ct = JsonConvert.DeserializeObject(diagramJson);
            DiagramJsonObject diagramJsonObject = JsonConvert.DeserializeObject<DiagramJsonObject>(diagramJson);
            //DiagramJsonObject diagramJsonObject = System.Text.Json.JsonSerializer.Deserialize<DiagramJsonObject>(diagramJson);


            //Map all Node ids with new GUID
            List<GUID_Mapper> GUIDmapper = new List<GUID_Mapper>();
            GUIDmapper.Add(new GUID_Mapper { nodeId = "00000000-0000-0000-0000-000000000000", GUID = Guid.Empty });
            foreach (var node in diagramJsonObject.nodes)
                GUIDmapper.Add(new GUID_Mapper { nodeId = node.id, GUID = Guid.NewGuid() });
            Nodelist = new List<ProcessSecrviceDTO>();
            //Index all nodes in diagram
            foreach (var node in diagramJsonObject.nodes)
            {
                string[] targetIds = new string[] { Guid.Empty.ToString(), Guid.Empty.ToString() };
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
                    formId = new Guid(node.addInfo.FormId),
                    outhUser = new List<string>() { node.addInfo.OuthUser },
                    GitwayVarKey = node.addInfo.GitwayVarKey,
                    GitwayVarValu = node.addInfo.GitwayVarValu,
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
