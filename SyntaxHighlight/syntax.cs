using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IERG3080_PRO3.SyntaxHighlight
{
    class syntax
    {
        public syntax()
        {
            using (var stream = new System.IO.MemoryStream(IERG3080_PRO3.Properties.Resources))
            {
                using (var reader = new System.Xml.XmlTextReader(stream))
                {
                    ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.RegisterHighlighting("SQL", new string[0],
                        ICSharpCode.AvalonEdit.Highlighting.Xshd.HighlightingLoader.Load(reader,
                            ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance));
                }
            }
    }
}
