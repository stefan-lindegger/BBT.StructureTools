﻿namespace BBT.StructureTools.Convert.Strategy
{
    using System.Collections.Generic;
    using BBT.StructureTools;
    using BBT.StructureTools.Convert;
    using BBT.StructureTools.Extension;

    /// <inheritdoc/>
    internal class OperationSubConvert<TSource, TTarget, TSourceValue, TTargetValue, TConvertIntention>
        : IOperationSubConvert<TSource, TTarget, TSourceValue, TTargetValue, TConvertIntention>
        where TSource : class
        where TTarget : class
        where TSourceValue : class
        where TTargetValue : class
        where TConvertIntention : IBaseConvertIntention
    {
        private readonly IConvert<TSourceValue, TTargetValue, TConvertIntention> convert;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationSubConvert{TSource, TTarget, TSourceValue, TTargetValue, TConvertIntention}" /> class.
        /// </summary>
        public OperationSubConvert(
            IConvert<TSourceValue, TTargetValue, TConvertIntention> convert)
        {
            convert.NotNull(nameof(convert));
            this.convert = convert;
        }

        /// <inheritdoc/>
        public void Execute(
            TSource source,
            TTarget target,
            ICollection<IBaseAdditionalProcessing> additionalProcessings)
        {
            source.NotNull(nameof(source));
            target.NotNull(nameof(target));
            additionalProcessings.NotNull(nameof(additionalProcessings));

            var targetValue = target as TTargetValue;
            if (source is TSourceValue sourceValue && targetValue != null)
            {
                this.convert.Convert(sourceValue, targetValue, additionalProcessings);
            }
        }
    }
}
