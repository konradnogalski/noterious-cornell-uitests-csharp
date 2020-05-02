using Infrastructure.PageObject.PageElements;
using NUnit.Framework;
using System;

namespace Infrastructure.FluentTestSteps
{
    public class RowActions<TCurrentRow> where TCurrentRow : Row
    {
        private Row _row;
        public RowActions(Row row)
        {
            _row = row;

        }

        public RowActions<TCurrentRow> Expect(Action<RowAssertActions<TCurrentRow>> assertActions)
        {
            Assert.Multiple(() => assertActions.Invoke(new RowAssertActions<TCurrentRow>(_row)));

            return this;
        }
    }
}
