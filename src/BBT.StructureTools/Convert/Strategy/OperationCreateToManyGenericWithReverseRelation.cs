﻿namespace BBT.StructureTools.Convert.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using BBT.StructureTools.Convert;
    using BBT.StructureTools.Extension;

    /// <inheritdoc/>
    internal class OperationCreateToManyGenericWithReverseRelation<TSource, TTarget, TSourceValue, TTargetValue, TConcreteTargetValue, TReverseRelation, TConvertIntention>
        : IOperationCreateToManyGenericWithReverseRelation<TSource, TTarget, TSourceValue, TTargetValue, TConcreteTargetValue, TReverseRelation, TConvertIntention>
        where TSource : class
        where TTarget : class, TReverseRelation
        where TSourceValue : class
        where TTargetValue : class
        where TConcreteTargetValue : TTargetValue, new()
        where TReverseRelation : class
        where TConvertIntention : IBaseConvertIntention
    {
        private readonly IConvertHelper convertHelper;

        private ICreateConvertHelper<TSourceValue, TTargetValue, TConcreteTargetValue, TReverseRelation, TConvertIntention> createConvertHelper;
        private Func<TSource, IEnumerable<TSourceValue>> sourceFunc;
        private Expression<Func<TTarget, IEnumerable<TTargetValue>>> targetexpression;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationCreateToManyGenericWithReverseRelation{TSource,TTarget,TSourceValue,TTargetValue,TConcreteTargetValue,TReverseRelation,TConvertIntention}" /> class.
        /// </summary>
        public OperationCreateToManyGenericWithReverseRelation(
            IConvertHelper convertHelper)
        {
            convertHelper.NotNull(nameof(convertHelper));

            this.convertHelper = convertHelper;
        }

        /// <inheritdoc/>
        public void Initialize(
            Func<TSource, IEnumerable<TSourceValue>> sourceFunc,
            Expression<Func<TTarget, IEnumerable<TTargetValue>>> targetExpression,
            ICreateConvertHelper<TSourceValue, TTargetValue, TConcreteTargetValue, TReverseRelation, TConvertIntention> createConvertHelper)
        {
            sourceFunc.NotNull(nameof(sourceFunc));
            targetExpression.NotNull(nameof(targetExpression));
            createConvertHelper.NotNull(nameof(createConvertHelper));

            this.sourceFunc = sourceFunc;
            this.targetexpression = targetExpression;
            this.createConvertHelper = createConvertHelper;
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

            var sourceValues = this.sourceFunc.Invoke(source);

            var copies = new List<TTargetValue>();

            foreach (var sourceValue in sourceValues)
            {
                if (!this.convertHelper.ContinueConvertProcess<TSourceValue, TTargetValue>(
                    sourceValue, additionalProcessings))
                {
                    continue;
                }

                var copy = this.createConvertHelper.CreateTarget(
                    sourceValue,
                    target,
                    additionalProcessings);
                copies.Add(copy);
            }

            target.SetPropertyValue(this.targetexpression, copies);
        }
    }
}