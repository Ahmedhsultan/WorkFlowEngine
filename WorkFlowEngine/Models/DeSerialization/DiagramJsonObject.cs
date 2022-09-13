namespace WorkFlowEngine.Models.DeSerialization
{
    public class DiagramJsonObject
    {

        public class Rootobject
        {
            public bool enableRtl { get; set; }
            public string locale { get; set; }
            public Animationcomplete animationComplete { get; set; }
            public Click click { get; set; }
            public Collectionchange collectionChange { get; set; }
            public Commandexecute commandExecute { get; set; }
            public Connectionchange connectionChange { get; set; }
            public Contextmenubeforeitemrender contextMenuBeforeItemRender { get; set; }
            public Contextmenuclick contextMenuClick { get; set; }
            public Contextmenuopen contextMenuOpen { get; set; }
            public Created created { get; set; }
            public Dataloaded dataLoaded { get; set; }
            public Doubleclick doubleClick { get; set; }
            public Dragenter dragEnter { get; set; }
            public Dragleave dragLeave { get; set; }
            public Dragover dragOver { get; set; }
            public Drop drop { get; set; }
            public Expandstatechange expandStateChange { get; set; }
            public Fixeduserhandleclick fixedUserHandleClick { get; set; }
            public Historychange historyChange { get; set; }
            public Historystatechange historyStateChange { get; set; }
            public Keydown keyDown { get; set; }
            public Keyup keyUp { get; set; }
            public Mouseenter mouseEnter { get; set; }
            public Mouseleave mouseLeave { get; set; }
            public Mouseover mouseOver { get; set; }
            public Onimageload onImageLoad { get; set; }
            public Onuserhandlemousedown onUserHandleMouseDown { get; set; }
            public Onuserhandlemouseenter onUserHandleMouseEnter { get; set; }
            public Onuserhandlemouseleave onUserHandleMouseLeave { get; set; }
            public Onuserhandlemouseup onUserHandleMouseUp { get; set; }
            public Positionchange positionChange { get; set; }
            public Propertychange propertyChange { get; set; }
            public Rotatechange rotateChange { get; set; }
            public Scrollchange scrollChange { get; set; }
            public Segmentcollectionchange segmentCollectionChange { get; set; }
            public Selectionchange selectionChange { get; set; }
            public Sizechange sizeChange { get; set; }
            public Sourcepointchange sourcePointChange { get; set; }
            public Targetpointchange targetPointChange { get; set; }
            public Textedit textEdit { get; set; }
            public string width { get; set; }
            public string height { get; set; }
            public Snapsettings snapSettings { get; set; }
            public Getconnectordefaults getConnectorDefaults { get; set; }
            public Getnodedefaults getNodeDefaults { get; set; }
            public Connector[] connectors { get; set; }
            public Node[] nodes { get; set; }
            public bool enablePersistence { get; set; }
            public Scrollsettings scrollSettings { get; set; }
            public Rulersettings rulerSettings { get; set; }
            public string backgroundColor { get; set; }
            public int constraints { get; set; }
            public Layout layout { get; set; }
            public Contextmenusettings contextMenuSettings { get; set; }
            public Datasourcesettings dataSourceSettings { get; set; }
            public string mode { get; set; }
            public Layer[] layers { get; set; }
            public Diagramsettings diagramSettings { get; set; }
            public Pagesettings pageSettings { get; set; }
            public Selecteditems selectedItems { get; set; }
            public object[] basicElements { get; set; }
            public Tooltip1 tooltip { get; set; }
            public Commandmanager commandManager { get; set; }
            public int tool { get; set; }
            public object[] customCursor { get; set; }
            public bool enableConnectorSplit { get; set; }
            public float version { get; set; }
        }

        public class Animationcomplete
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Click
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Collectionchange
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Commandexecute
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Connectionchange
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Contextmenubeforeitemrender
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Contextmenuclick
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Contextmenuopen
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Created
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Dataloaded
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Doubleclick
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Dragenter
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Dragleave
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Dragover
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Drop
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Expandstatechange
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Fixeduserhandleclick
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Historychange
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Historystatechange
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Keydown
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Keyup
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Mouseenter
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Mouseleave
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Mouseover
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Onimageload
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Onuserhandlemousedown
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Onuserhandlemouseenter
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Onuserhandlemouseleave
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Onuserhandlemouseup
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Positionchange
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Propertychange
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Rotatechange
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Scrollchange
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Segmentcollectionchange
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Selectionchange
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Sizechange
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Sourcepointchange
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Targetpointchange
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Textedit
        {
            public bool _isScalar { get; set; }
            public bool closed { get; set; }
            public bool isStopped { get; set; }
            public bool hasError { get; set; }
            public object thrownError { get; set; }
            public bool __isAsync { get; set; }
        }

        public class Snapsettings
        {
            public Horizontalgridlines horizontalGridlines { get; set; }
            public Verticalgridlines verticalGridlines { get; set; }
            public int constraints { get; set; }
            public string gridType { get; set; }
        }

        public class Horizontalgridlines
        {
            public string lineColor { get; set; }
            public float[] lineIntervals { get; set; }
            public int[] snapIntervals { get; set; }
            public string lineDashArray { get; set; }
        }

        public class Verticalgridlines
        {
            public string lineColor { get; set; }
            public float[] lineIntervals { get; set; }
            public int[] snapIntervals { get; set; }
            public string lineDashArray { get; set; }
        }

        public class Getconnectordefaults
        {
        }

        public class Getnodedefaults
        {
        }

        public class Scrollsettings
        {
            public float viewPortWidth { get; set; }
            public int viewPortHeight { get; set; }
            public int currentZoom { get; set; }
            public float horizontalOffset { get; set; }
            public int verticalOffset { get; set; }
            public Padding padding { get; set; }
            public string scrollLimit { get; set; }
            public float minZoom { get; set; }
            public int maxZoom { get; set; }
            public bool canAutoScroll { get; set; }
        }

        public class Padding
        {
            public int left { get; set; }
            public int right { get; set; }
            public int top { get; set; }
            public int bottom { get; set; }
        }

        public class Rulersettings
        {
            public bool showRulers { get; set; }
        }

        public class Layout
        {
            public string type { get; set; }
            public bool enableAnimation { get; set; }
            public string connectionPointOrigin { get; set; }
            public string arrangement { get; set; }
            public bool enableRouting { get; set; }
        }

        public class Contextmenusettings
        {
        }

        public class Datasourcesettings
        {
            public object dataManager { get; set; }
            public object dataSource { get; set; }
            public Crudaction crudAction { get; set; }
            public Connectiondatasource connectionDataSource { get; set; }
        }

        public class Crudaction
        {
            public string read { get; set; }
        }

        public class Connectiondatasource
        {
            public Crudaction1 crudAction { get; set; }
        }

        public class Crudaction1
        {
            public string read { get; set; }
        }

        public class Diagramsettings
        {
            public bool inversedAlignment { get; set; }
        }

        public class Pagesettings
        {
            public string boundaryConstraints { get; set; }
            public string orientation { get; set; }
            public object height { get; set; }
            public object width { get; set; }
            public Background background { get; set; }
            public bool showPageBreaks { get; set; }
            public Fitoptions fitOptions { get; set; }
            public bool multiplePage { get; set; }
        }

        public class Background
        {
            public string source { get; set; }
            public string color { get; set; }
        }

        public class Fitoptions
        {
            public bool canFit { get; set; }
        }

        public class Selecteditems
        {
            public object[] nodes { get; set; }
            public object[] connectors { get; set; }
            public object wrapper { get; set; }
            public int constraints { get; set; }
            public Selectedobject[] selectedObjects { get; set; }
            public object[] userHandles { get; set; }
            public int rotateAngle { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public float offsetX { get; set; }
            public float offsetY { get; set; }
            public Pivot pivot { get; set; }
        }

        public class Pivot
        {
            public float x { get; set; }
            public float y { get; set; }
        }

        public class Selectedobject
        {
            public Shape shape { get; set; }
            public Port[] ports { get; set; }
            public string id { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public object container { get; set; }
            public float offsetX { get; set; }
            public float offsetY { get; set; }
            public bool visible { get; set; }
            public string horizontalAlignment { get; set; }
            public string verticalAlignment { get; set; }
            public string backgroundColor { get; set; }
            public string borderColor { get; set; }
            public int borderWidth { get; set; }
            public int rotateAngle { get; set; }
            public Pivot1 pivot { get; set; }
            public Margin margin { get; set; }
            public string flip { get; set; }
            public Wrapper wrapper { get; set; }
            public int constraints { get; set; }
            public Style style { get; set; }
            public Previewsize previewSize { get; set; }
            public Dragsize dragSize { get; set; }
            public int zIndex { get; set; }
            public Annotation[] annotations { get; set; }
            public string flipMode { get; set; }
            public bool isExpanded { get; set; }
            public Expandicon expandIcon { get; set; }
            public object[] fixedUserHandles { get; set; }
            public Tooltip tooltip { get; set; }
            public object[] inEdges { get; set; }
            public object[] outEdges { get; set; }
            public string parentId { get; set; }
            public string processId { get; set; }
            public int umlIndex { get; set; }
            public bool isPhase { get; set; }
            public bool isLane { get; set; }
        }

        public class Shape
        {
            public string type { get; set; }
            public string shape { get; set; }
        }

        public class Pivot1
        {
            public float x { get; set; }
            public float y { get; set; }
        }

        public class Margin
        {
        }

        public class Wrapper
        {
            public Actualsize actualSize { get; set; }
            public float offsetX { get; set; }
            public float offsetY { get; set; }
        }

        public class Actualsize
        {
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Style
        {
            public string fill { get; set; }
            public Gradient gradient { get; set; }
            public int strokeWidth { get; set; }
            public string strokeColor { get; set; }
            public string strokeDashArray { get; set; }
            public int opacity { get; set; }
        }

        public class Gradient
        {
            public string type { get; set; }
        }

        public class Previewsize
        {
        }

        public class Dragsize
        {
        }

        public class Expandicon
        {
            public string shape { get; set; }
        }

        public class Tooltip
        {
            public string openOn { get; set; }
        }

        public class Port
        {
            public object[] inEdges { get; set; }
            public object[] outEdges { get; set; }
            public string id { get; set; }
            public string shape { get; set; }
            public Offset offset { get; set; }
            public int height { get; set; }
            public int width { get; set; }
            public Margin1 margin { get; set; }
            public Style1 style { get; set; }
            public string horizontalAlignment { get; set; }
            public string verticalAlignment { get; set; }
            public int visibility { get; set; }
        }

        public class Offset
        {
            public float x { get; set; }
            public float y { get; set; }
        }

        public class Margin1
        {
            public int right { get; set; }
            public int bottom { get; set; }
            public int left { get; set; }
            public int top { get; set; }
        }

        public class Style1
        {
            public string fill { get; set; }
            public string strokeColor { get; set; }
            public int opacity { get; set; }
            public string strokeDashArray { get; set; }
            public int strokeWidth { get; set; }
        }

        public class Annotation
        {
            public string id { get; set; }
            public Style2 style { get; set; }
            public string content { get; set; }
            public string annotationType { get; set; }
            public Hyperlink hyperlink { get; set; }
            public int constraints { get; set; }
            public bool visibility { get; set; }
            public int rotateAngle { get; set; }
            public Margin2 margin { get; set; }
            public string horizontalAlignment { get; set; }
            public string verticalAlignment { get; set; }
            public Offset1 offset { get; set; }
        }

        public class Style2
        {
            public int strokeWidth { get; set; }
            public string strokeColor { get; set; }
            public string fill { get; set; }
            public string color { get; set; }
            public bool bold { get; set; }
            public string textWrapping { get; set; }
            public string whiteSpace { get; set; }
            public string fontFamily { get; set; }
            public int fontSize { get; set; }
            public bool italic { get; set; }
            public int opacity { get; set; }
            public string strokeDashArray { get; set; }
            public string textAlign { get; set; }
            public string textOverflow { get; set; }
            public string textDecoration { get; set; }
        }

        public class Hyperlink
        {
            public string link { get; set; }
            public string hyperlinkOpenState { get; set; }
            public string content { get; set; }
            public string textDecoration { get; set; }
        }

        public class Margin2
        {
            public int right { get; set; }
            public int bottom { get; set; }
            public int left { get; set; }
            public int top { get; set; }
        }

        public class Offset1
        {
            public float x { get; set; }
            public float y { get; set; }
        }

        public class Tooltip1
        {
            public string content { get; set; }
        }

        public class Commandmanager
        {
            public object[] commands { get; set; }
        }

        public class Connector
        {
            public Shape1 shape { get; set; }
            public string id { get; set; }
            public string sourceID { get; set; }
            public string targetID { get; set; }
            public int zIndex { get; set; }
            public string type { get; set; }
            public Targetdecorator targetDecorator { get; set; }
            public Segment[] segments { get; set; }
            public string sourcePortID { get; set; }
            public string targetPortID { get; set; }
            public Targetpoint targetPoint { get; set; }
            public int connectorSpacing { get; set; }
            public int sourcePadding { get; set; }
            public int targetPadding { get; set; }
            public Sourcepoint sourcePoint { get; set; }
            public Sourcedecorator sourceDecorator { get; set; }
            public int cornerRadius { get; set; }
            public Wrapper1 wrapper { get; set; }
            public Style5 style { get; set; }
            public object[] annotations { get; set; }
            public object[] fixedUserHandles { get; set; }
            public bool visible { get; set; }
            public int constraints { get; set; }
            public int hitPadding { get; set; }
            public string parentId { get; set; }
            public string flip { get; set; }
            public Previewsize1 previewSize { get; set; }
            public int connectionPadding { get; set; }
            public Tooltip2 tooltip { get; set; }
        }

        public class Shape1
        {
            public string type { get; set; }
        }

        public class Targetdecorator
        {
            public string shape { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public Pivot2 pivot { get; set; }
            public Style3 style { get; set; }
        }

        public class Pivot2
        {
            public int x { get; set; }
            public float y { get; set; }
        }

        public class Style3
        {
            public string fill { get; set; }
            public string strokeColor { get; set; }
            public int strokeWidth { get; set; }
            public string strokeDashArray { get; set; }
            public int opacity { get; set; }
            public Gradient1 gradient { get; set; }
        }

        public class Gradient1
        {
            public string type { get; set; }
        }

        public class Targetpoint
        {
            public float x { get; set; }
            public float y { get; set; }
        }

        public class Sourcepoint
        {
            public float x { get; set; }
            public float y { get; set; }
        }

        public class Sourcedecorator
        {
            public string shape { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public Pivot3 pivot { get; set; }
            public Style4 style { get; set; }
        }

        public class Pivot3
        {
            public int x { get; set; }
            public float y { get; set; }
        }

        public class Style4
        {
            public string fill { get; set; }
            public string strokeColor { get; set; }
            public int strokeWidth { get; set; }
            public string strokeDashArray { get; set; }
            public int opacity { get; set; }
            public Gradient2 gradient { get; set; }
        }

        public class Gradient2
        {
            public string type { get; set; }
        }

        public class Wrapper1
        {
            public Actualsize1 actualSize { get; set; }
            public float offsetX { get; set; }
            public float offsetY { get; set; }
        }

        public class Actualsize1
        {
            public float width { get; set; }
            public float height { get; set; }
        }

        public class Style5
        {
            public int strokeWidth { get; set; }
            public string strokeColor { get; set; }
            public string fill { get; set; }
            public string strokeDashArray { get; set; }
            public int opacity { get; set; }
            public Gradient3 gradient { get; set; }
        }

        public class Gradient3
        {
            public string type { get; set; }
        }

        public class Previewsize1
        {
        }

        public class Tooltip2
        {
            public string openOn { get; set; }
        }

        public class Segment
        {
            public string type { get; set; }
            public object direction { get; set; }
            public object length { get; set; }
        }

        public class Node
        {
            public Shape2 shape { get; set; }
            public Port1[] ports { get; set; }
            public string id { get; set; }
            public int height { get; set; }
            public float offsetX { get; set; }
            public float offsetY { get; set; }
            public Annotation1[] annotations { get; set; }
            public int zIndex { get; set; }
            public int width { get; set; }
            public Style6 style { get; set; }
            public object container { get; set; }
            public bool visible { get; set; }
            public string horizontalAlignment { get; set; }
            public string verticalAlignment { get; set; }
            public string backgroundColor { get; set; }
            public string borderColor { get; set; }
            public int borderWidth { get; set; }
            public int rotateAngle { get; set; }
            public Pivot4 pivot { get; set; }
            public Margin3 margin { get; set; }
            public string flip { get; set; }
            public Wrapper2 wrapper { get; set; }
            public int constraints { get; set; }
            public string flipMode { get; set; }
            public bool isExpanded { get; set; }
            public Expandicon1 expandIcon { get; set; }
            public object[] fixedUserHandles { get; set; }
            public Tooltip3 tooltip { get; set; }
            public string[] inEdges { get; set; }
            public string[] outEdges { get; set; }
            public string parentId { get; set; }
            public string processId { get; set; }
            public int umlIndex { get; set; }
            public bool isPhase { get; set; }
            public bool isLane { get; set; }
            public Previewsize2 previewSize { get; set; }
            public Dragsize1 dragSize { get; set; }
        }

        public class Shape2
        {
            public string type { get; set; }
            public string shape { get; set; }
        }

        public class Style6
        {
            public string fill { get; set; }
            public string strokeColor { get; set; }
            public Gradient4 gradient { get; set; }
            public int strokeWidth { get; set; }
            public string strokeDashArray { get; set; }
            public int opacity { get; set; }
        }

        public class Gradient4
        {
            public string type { get; set; }
        }

        public class Pivot4
        {
            public float x { get; set; }
            public float y { get; set; }
        }

        public class Margin3
        {
        }

        public class Wrapper2
        {
            public Actualsize2 actualSize { get; set; }
            public float offsetX { get; set; }
            public float offsetY { get; set; }
        }

        public class Actualsize2
        {
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Expandicon1
        {
            public string shape { get; set; }
        }

        public class Tooltip3
        {
            public string openOn { get; set; }
        }

        public class Previewsize2
        {
        }

        public class Dragsize1
        {
        }

        public class Port1
        {
            public string id { get; set; }
            public string shape { get; set; }
            public Offset2 offset { get; set; }
            public object[] inEdges { get; set; }
            public object[] outEdges { get; set; }
            public int height { get; set; }
            public int width { get; set; }
            public Margin4 margin { get; set; }
            public Style7 style { get; set; }
            public string horizontalAlignment { get; set; }
            public string verticalAlignment { get; set; }
            public int visibility { get; set; }
            public int constraints { get; set; }
        }

        public class Offset2
        {
            public float x { get; set; }
            public float y { get; set; }
        }

        public class Margin4
        {
            public int right { get; set; }
            public int bottom { get; set; }
            public int left { get; set; }
            public int top { get; set; }
        }

        public class Style7
        {
            public string fill { get; set; }
            public string strokeColor { get; set; }
            public int opacity { get; set; }
            public string strokeDashArray { get; set; }
            public int strokeWidth { get; set; }
        }

        public class Annotation1
        {
            public string id { get; set; }
            public string content { get; set; }
            public Style8 style { get; set; }
            public string annotationType { get; set; }
            public Hyperlink1 hyperlink { get; set; }
            public int constraints { get; set; }
            public bool visibility { get; set; }
            public int rotateAngle { get; set; }
            public Margin5 margin { get; set; }
            public string horizontalAlignment { get; set; }
            public string verticalAlignment { get; set; }
            public Offset3 offset { get; set; }
        }

        public class Style8
        {
            public int strokeWidth { get; set; }
            public string strokeColor { get; set; }
            public string fill { get; set; }
            public string color { get; set; }
            public bool bold { get; set; }
            public string textWrapping { get; set; }
            public string whiteSpace { get; set; }
            public string fontFamily { get; set; }
            public int fontSize { get; set; }
            public bool italic { get; set; }
            public int opacity { get; set; }
            public string strokeDashArray { get; set; }
            public string textAlign { get; set; }
            public string textOverflow { get; set; }
            public string textDecoration { get; set; }
        }

        public class Hyperlink1
        {
            public string link { get; set; }
            public string hyperlinkOpenState { get; set; }
            public string content { get; set; }
            public string textDecoration { get; set; }
        }

        public class Margin5
        {
            public int right { get; set; }
            public int bottom { get; set; }
            public int left { get; set; }
            public int top { get; set; }
        }

        public class Offset3
        {
            public float x { get; set; }
            public float y { get; set; }
        }

        public class Layer
        {
            public string id { get; set; }
            public bool visible { get; set; }
            public bool _lock { get; set; }
            public string[] objects { get; set; }
            public int zIndex { get; set; }
            public int objectZIndex { get; set; }
        }
    }
}
