using SimpleCalculator.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace SimpleCalculator3.Operations {

    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '+')]
    class Add : IOperation {
        public int Operate(int left, int right) {
            return left + right;
        }
    }

}
