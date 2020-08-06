﻿namespace BBT.StructureTools.Convert.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using BBT.StructureTools.Convert;

    /// <summary>
    /// Strategy to convert entities with a <c>ToMany</c> relationship.
    /// See <see cref="IConvertOperation{TSource,TTarget}"/>.
    /// </summary>
    public interface IOperationCreateToOneHistWithCondition<TSource, TTarget, TSourceValue, TTargetValue, TConcreteTargetValue, TReverseRelation, TTemporalData, TConvertIntention>
        : IConvertOperation<TSource, TTarget>
        where TSource : class
        where TTarget : class
        where TSourceValue : class, TTemporalData
        where TTargetValue : class, TTemporalData
        where TConcreteTargetValue : TTargetValue, new()
        where TReverseRelation : class
        where TTemporalData : class
        where TConvertIntention : IBaseConvertIntention
    {
        /// <summary>
        /// Initializes the <see cref="IConvertOperation{TSource,TTarget}"/>.
        /// </summary>
        /// <param name="sourceFunc">Declares the filtered source values.</param>
        /// <param name="targetExpression">Declares the collection property on target.</param>
        /// <param name="toOneHistCriteria">If true create one everlasting hist segemnt, otherwise copy all.</param>
        /// <param name="toOneReferenceDate">Reference date to select hist segment on source.</param>
        /// <param name="createConvertHelper">Used to create the collection entries on target.</param>
        void Initialize(
            Func<TSource, TTarget, IEnumerable<TSourceValue>> sourceFunc,
            Expression<Func<TTarget, ICollection<TTargetValue>>> targetExpression,
            Func<TSource, TTarget, bool> toOneHistCriteria,
            Func<TSource, TTarget, DateTime> toOneReferenceDate,
            ICreateConvertHelper<TSourceValue, TTargetValue, TConcreteTargetValue, TReverseRelation, TConvertIntention> createConvertHelper);
    }
}
