namespace ExternalLib
{
    public class ProgramParam
    {
        public string ParamName { get; set; }
        public string ParamDesc { get; set; }
        public double ParamVal { get; set; }

        public ProgramParam()
        {

        }
        public ProgramParam(string paramName, string paramDesc, double paramVal)
        {
            ParamName = paramName;
            ParamDesc = paramDesc;
            ParamVal = paramVal;
        }
    }
}