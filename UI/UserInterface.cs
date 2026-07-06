using IntelligencePipeline.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligencePipeline.UI
{
    public class UserInterface : BaseUI
    {
        private AnalyzerUI analyzer;
        private ReporterUI reporter;
        public UserInterface(ReportPipeline pipeline) : base(pipeline)
        {
            analyzer = new AnalyzerUI(pipeline);
            reporter = new ReporterUI(pipeline);
        }


    }
}
