﻿namespace BBT.StructureTools.Convert.Strategy
{
    using System.Collections.Generic;
    using BBT.StructureTools.Extension;

    /// <inheritdoc/>
    internal class OperationConvertPostProcessing<TSource, TTarget> : IOperationConvertPostProcessing<TSource, TTarget>
            where TSource : class
            where TTarget : class
    {
        private readonly ICollection<IBaseAdditionalProcessing> additionalProcessings;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationConvertPostProcessing{TSource, TTarget}" /> class.
        /// </summary>
        public OperationConvertPostProcessing(ICollection<IBaseAdditionalProcessing> additionalProcessings)
        {
            additionalProcessings.NotNull(nameof(additionalProcessings));

            this.additionalProcessings = additionalProcessings;
        }

        /// <inheritdoc/>
        public void Execute(TSource source, TTarget target, ICollection<IBaseAdditionalProcessing> additionalProcessings)
        {
            additionalProcessings.NotNull(nameof(additionalProcessings));

            additionalProcessings.AddRangeToMe(this.additionalProcessings);
        }
    }
}