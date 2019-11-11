
var camelCaseTokenizer = function (builder) {

  var pipelineFunction = function (token) {
    var previous = '';
    // split camelCaseString to on each word and combined words
    // e.g. camelCaseTokenizer -> ['camel', 'case', 'camelcase', 'tokenizer', 'camelcasetokenizer']
    var tokenStrings = token.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
      var current = cur.toLowerCase();
      if (acc.length === 0) {
        previous = current;
        return acc.concat(current);
      }
      previous = previous.concat(current);
      return acc.concat([current, previous]);
    }, []);

    // return token for each string
    // will copy any metadata on input token
    return tokenStrings.map(function(tokenString) {
      return token.clone(function(str) {
        return tokenString;
      })
    });
  }

  lunr.Pipeline.registerFunction(pipelineFunction, 'camelCaseTokenizer')

  builder.pipeline.before(lunr.stemmer, pipelineFunction)
}
var searchModule = function() {
    var documents = [];
    var idMap = [];
    function a(a,b) { 
        documents.push(a);
        idMap.push(b); 
    }

    a(
        {
            id:0,
            title:"ICreateConvertHelper",
            content:"ICreateConvertHelper",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/ICreateConvertHelper_5',
            title:"ICreateConvertHelper<TSource, TTarget, TConcreteTarget, TReverseRelation, TConvertIntention>",
            description:""
        }
    );
    a(
        {
            id:1,
            title:"ISourceConvertStrategy",
            content:"ISourceConvertStrategy",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert.Strategy/ISourceConvertStrategy_3',
            title:"ISourceConvertStrategy<TBaseSource, TBaseTarget, TIntention>",
            description:""
        }
    );
    a(
        {
            id:2,
            title:"IConvertValue",
            content:"IConvertValue",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert.Value/IConvertValue_2',
            title:"IConvertValue<TSource, TTarget>",
            description:""
        }
    );
    a(
        {
            id:3,
            title:"ConvertEngine",
            content:"ConvertEngine",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/ConvertEngine_2',
            title:"ConvertEngine<TSource, TTarget>",
            description:""
        }
    );
    a(
        {
            id:4,
            title:"IGenericContinueCopyInterception",
            content:"IGenericContinueCopyInterception",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy.Processing/IGenericContinueCopyInterception_1',
            title:"IGenericContinueCopyInterception<TType>",
            description:""
        }
    );
    a(
        {
            id:5,
            title:"ICreateInstanceOfTypeStrategy",
            content:"ICreateInstanceOfTypeStrategy",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Strategy/ICreateInstanceOfTypeStrategy_1',
            title:"ICreateInstanceOfTypeStrategy<TBaseTypeIntf>",
            description:""
        }
    );
    a(
        {
            id:6,
            title:"ModelCollectingConvertPostProcessing",
            content:"ModelCollectingConvertPostProcessing",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/ModelCollectingConvertPostProcessing_2',
            title:"ModelCollectingConvertPostProcessing<TSource, TTarget>",
            description:""
        }
    );
    a(
        {
            id:7,
            title:"ITargetConvertStrategy",
            content:"ITargetConvertStrategy",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert.Strategy/ITargetConvertStrategy_3',
            title:"ITargetConvertStrategy<TBaseSource, TBaseTarget, TIntention>",
            description:""
        }
    );
    a(
        {
            id:8,
            title:"ICreateConvertHelper",
            content:"ICreateConvertHelper",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/ICreateConvertHelper_4',
            title:"ICreateConvertHelper<TSource, TTarget, TConcreteTarget, TConvertIntention>",
            description:""
        }
    );
    a(
        {
            id:9,
            title:"Converter",
            content:"Converter",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/Converter_3',
            title:"Converter<TSource, TTarget, TConvertIntention>",
            description:""
        }
    );
    a(
        {
            id:10,
            title:"ConvertOperations",
            content:"ConvertOperations",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/ConvertOperations_2',
            title:"ConvertOperations<TSource, TTarget>",
            description:""
        }
    );
    a(
        {
            id:11,
            title:"IBaseConvertIntention",
            content:"IBaseConvertIntention",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/IBaseConvertIntention',
            title:"IBaseConvertIntention",
            description:""
        }
    );
    a(
        {
            id:12,
            title:"GenericConvertPostProcessing",
            content:"GenericConvertPostProcessing",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/GenericConvertPostProcessing_2',
            title:"GenericConvertPostProcessing<TSoureClass, TTargetClass>",
            description:""
        }
    );
    a(
        {
            id:13,
            title:"GenericFilterByReferenceDateProcessing",
            content:"GenericFilterByReferenceDateProcessing",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/GenericFilterByReferenceDateProcessing_2',
            title:"GenericFilterByReferenceDateProcessing<TSourceClass, TTargetClass>",
            description:""
        }
    );
    a(
        {
            id:14,
            title:"GenericContinueConvertInterception",
            content:"GenericContinueConvertInterception",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/GenericContinueConvertInterception_2',
            title:"GenericContinueConvertInterception<TSoureClass, TTargetClass>",
            description:""
        }
    );
    a(
        {
            id:15,
            title:"GenericComparePostProcessing",
            content:"GenericComparePostProcessing",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare/GenericComparePostProcessing_2',
            title:"GenericComparePostProcessing<T, TIntention>",
            description:""
        }
    );
    a(
        {
            id:16,
            title:"IConvertPostProcessing",
            content:"IConvertPostProcessing",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/IConvertPostProcessing_2',
            title:"IConvertPostProcessing<TSoureClass, TTargetClass>",
            description:""
        }
    );
    a(
        {
            id:17,
            title:"IConvertOperations",
            content:"IConvertOperations",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/IConvertOperations_2',
            title:"IConvertOperations<TSource, TTarget>",
            description:""
        }
    );
    a(
        {
            id:18,
            title:"ICompareRegistrations",
            content:"ICompareRegistrations",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare/ICompareRegistrations_2',
            title:"ICompareRegistrations<TModelToCompare, TCompareIntention>",
            description:""
        }
    );
    a(
        {
            id:19,
            title:"IConvertWithReverseRelation",
            content:"IConvertWithReverseRelation",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/IConvertWithReverseRelation_4',
            title:"IConvertWithReverseRelation<TSourceClass, TTargetClass, TReverseRelation, TConvertIntention>",
            description:""
        }
    );
    a(
        {
            id:20,
            title:"ICopyHelperRegistration",
            content:"ICopyHelperRegistration",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy.Helper/ICopyHelperRegistration_1',
            title:"ICopyHelperRegistration<T>",
            description:""
        }
    );
    a(
        {
            id:21,
            title:"GenericCopyPostProcessing",
            content:"GenericCopyPostProcessing",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy.Processing/GenericCopyPostProcessing_1',
            title:"GenericCopyPostProcessing<TClassToCopy>",
            description:""
        }
    );
    a(
        {
            id:22,
            title:"EqualityComparerHelperRegistrationFactory",
            content:"EqualityComparerHelperRegistrationFactory",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare.Helper/EqualityComparerHelperRegistrationFactory',
            title:"EqualityComparerHelperRegistrationFactory",
            description:""
        }
    );
    a(
        {
            id:23,
            title:"ICopyWithParent",
            content:"ICopyWithParent",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy/ICopyWithParent_2',
            title:"ICopyWithParent<TClassToCopy, TParent>",
            description:""
        }
    );
    a(
        {
            id:24,
            title:"ICreateCopyHelper",
            content:"ICreateCopyHelper",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy/ICreateCopyHelper_2',
            title:"ICreateCopyHelper<TTarget, TConcreteTarget>",
            description:""
        }
    );
    a(
        {
            id:25,
            title:"IFlatComparer",
            content:"IFlatComparer",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare/IFlatComparer',
            title:"IFlatComparer",
            description:""
        }
    );
    a(
        {
            id:26,
            title:"IConvertInterception",
            content:"IConvertInterception",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/IConvertInterception_2',
            title:"IConvertInterception<TSoureClass, TTargetClass>",
            description:""
        }
    );
    a(
        {
            id:27,
            title:"ICopy",
            content:"ICopy",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy/ICopy_1',
            title:"ICopy<TClassToCopy>",
            description:""
        }
    );
    a(
        {
            id:28,
            title:"IComparerExclusion",
            content:"IComparerExclusion",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare/IComparerExclusion',
            title:"IComparerExclusion",
            description:""
        }
    );
    a(
        {
            id:29,
            title:"PropertyComparerExclusion",
            content:"PropertyComparerExclusion",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare.Exclusions/PropertyComparerExclusion_1',
            title:"PropertyComparerExclusion<TModelInterface>",
            description:""
        }
    );
    a(
        {
            id:30,
            title:"SubInterfaceComparerExclusion",
            content:"SubInterfaceComparerExclusion",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare.Exclusions/SubInterfaceComparerExclusion_1',
            title:"SubInterfaceComparerExclusion<TSubInterface>",
            description:""
        }
    );
    a(
        {
            id:31,
            title:"ModelCollectingCopyPostProcessing",
            content:"ModelCollectingCopyPostProcessing",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy/ModelCollectingCopyPostProcessing_1',
            title:"ModelCollectingCopyPostProcessing<TClassToCopy>",
            description:""
        }
    );
    a(
        {
            id:32,
            title:"IConvert",
            content:"IConvert",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/IConvert_3',
            title:"IConvert<TSourceClass, TTargetClass, TConvertIntention>",
            description:""
        }
    );
    a(
        {
            id:33,
            title:"IIocResolver",
            content:"IIocResolver",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Initialization/IIocResolver',
            title:"IIocResolver",
            description:""
        }
    );
    a(
        {
            id:34,
            title:"IBaseAdditionalProcessing",
            content:"IBaseAdditionalProcessing",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools/IBaseAdditionalProcessing',
            title:"IBaseAdditionalProcessing",
            description:""
        }
    );
    a(
        {
            id:35,
            title:"IValueConvertMapping",
            content:"IValueConvertMapping",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert.Value/IValueConvertMapping_2',
            title:"IValueConvertMapping<TSource, TTarget>",
            description:""
        }
    );
    a(
        {
            id:36,
            title:"IConvertRegistrations",
            content:"IConvertRegistrations",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/IConvertRegistrations_3',
            title:"IConvertRegistrations<TSource, TTarget, TConvertIntention>",
            description:""
        }
    );
    a(
        {
            id:37,
            title:"IComparePostProcessing",
            content:"IComparePostProcessing",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare/IComparePostProcessing_2',
            title:"IComparePostProcessing<T, TIntention>",
            description:""
        }
    );
    a(
        {
            id:38,
            title:"IEqualityComparerHelperRegistrationFactory",
            content:"IEqualityComparerHelperRegistrationFactory",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare.Helper/IEqualityComparerHelperRegistrationFactory',
            title:"IEqualityComparerHelperRegistrationFactory",
            description:""
        }
    );
    a(
        {
            id:39,
            title:"ModelIntComparer",
            content:"ModelIntComparer",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare/ModelIntComparer_1',
            title:"ModelIntComparer<TModel>",
            description:""
        }
    );
    a(
        {
            id:40,
            title:"IConvertValueRegistration",
            content:"IConvertValueRegistration",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert.Value/IConvertValueRegistration_2',
            title:"IConvertValueRegistration<TSource, TTarget>",
            description:""
        }
    );
    a(
        {
            id:41,
            title:"ICopyStrategy",
            content:"ICopyStrategy",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy.Strategy/ICopyStrategy_1',
            title:"ICopyStrategy<T>",
            description:""
        }
    );
    a(
        {
            id:42,
            title:"CreateConvertHelper",
            content:"CreateConvertHelper",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/CreateConvertHelper_4',
            title:"CreateConvertHelper<TSource, TTarget, TConcreteTarget, TConvertIntention>",
            description:""
        }
    );
    a(
        {
            id:43,
            title:"ICreateCopyHelper",
            content:"ICreateCopyHelper",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy/ICreateCopyHelper_3',
            title:"ICreateCopyHelper<TChild, TConcreteChild, TParent>",
            description:""
        }
    );
    a(
        {
            id:44,
            title:"ConvertHelperFactory",
            content:"ConvertHelperFactory",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/ConvertHelperFactory_4',
            title:"ConvertHelperFactory<TSource, TTarget, TConcreteTarget, TConvertIntention>",
            description:""
        }
    );
    a(
        {
            id:45,
            title:"ConvertHelper",
            content:"ConvertHelper",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/ConvertHelper',
            title:"ConvertHelper",
            description:""
        }
    );
    a(
        {
            id:46,
            title:"IConvertValueRegistrations",
            content:"IConvertValueRegistrations",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert.Value/IConvertValueRegistrations_2',
            title:"IConvertValueRegistrations<TSource, TTarget>",
            description:""
        }
    );
    a(
        {
            id:47,
            title:"ICopyRegistrationMarker",
            content:"ICopyRegistrationMarker",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy.Marker/ICopyRegistrationMarker',
            title:"ICopyRegistrationMarker",
            description:""
        }
    );
    a(
        {
            id:48,
            title:"ICopyRegistrations",
            content:"ICopyRegistrations",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy/ICopyRegistrations_1',
            title:"ICopyRegistrations<T>",
            description:""
        }
    );
    a(
        {
            id:49,
            title:"CreateConvertHelper",
            content:"CreateConvertHelper",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/CreateConvertHelper_5',
            title:"CreateConvertHelper<TSource, TTarget, TConcreteTarget, TReverseRelation, TConvertIntention>",
            description:""
        }
    );
    a(
        {
            id:50,
            title:"GenericContinueCopyInterception",
            content:"GenericContinueCopyInterception",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy.Processing/GenericContinueCopyInterception_1',
            title:"GenericContinueCopyInterception<TType>",
            description:""
        }
    );
    a(
        {
            id:51,
            title:"TypeOfComparerExclusion",
            content:"TypeOfComparerExclusion",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare/TypeOfComparerExclusion',
            title:"TypeOfComparerExclusion",
            description:""
        }
    );
    a(
        {
            id:52,
            title:"ITemporalDataDescriptor",
            content:"ITemporalDataDescriptor",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/ITemporalDataDescriptor_1',
            title:"ITemporalDataDescriptor<T>",
            description:""
        }
    );
    a(
        {
            id:53,
            title:"ICreateByBaseAsCriterionStrategy",
            content:"ICreateByBaseAsCriterionStrategy",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Strategy/ICreateByBaseAsCriterionStrategy_2',
            title:"ICreateByBaseAsCriterionStrategy<TBaseInterface, TInterface>",
            description:""
        }
    );
    a(
        {
            id:54,
            title:"GenericConvertPreProcessing",
            content:"GenericConvertPreProcessing",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/GenericConvertPreProcessing_2',
            title:"GenericConvertPreProcessing<TSoureClass, TTargetClass>",
            description:""
        }
    );
    a(
        {
            id:55,
            title:"IConvertHelperFactory",
            content:"IConvertHelperFactory",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/IConvertHelperFactory_4',
            title:"IConvertHelperFactory<TSource, TTarget, TConcreteTarget, TConvertIntention>",
            description:""
        }
    );
    a(
        {
            id:56,
            title:"IConvertRegistration",
            content:"IConvertRegistration",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/IConvertRegistration_2',
            title:"IConvertRegistration<TSource, TTarget>",
            description:""
        }
    );
    a(
        {
            id:57,
            title:"IConvertPreProcessing",
            content:"IConvertPreProcessing",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/IConvertPreProcessing_2',
            title:"IConvertPreProcessing<TSoureClass, TTargetClass>",
            description:""
        }
    );
    a(
        {
            id:58,
            title:"ICopyCallContext",
            content:"ICopyCallContext",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy/ICopyCallContext',
            title:"ICopyCallContext",
            description:""
        }
    );
    a(
        {
            id:59,
            title:"ICopyMarker",
            content:"ICopyMarker",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy.Marker/ICopyMarker',
            title:"ICopyMarker",
            description:""
        }
    );
    a(
        {
            id:60,
            title:"IComparer",
            content:"IComparer",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare/IComparer_2',
            title:"IComparer<TModelToCompare, TComparerIntention>",
            description:""
        }
    );
    a(
        {
            id:61,
            title:"ConvertRegistration",
            content:"ConvertRegistration",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Convert/ConvertRegistration_2',
            title:"ConvertRegistration<TSource, TTarget>",
            description:""
        }
    );
    a(
        {
            id:62,
            title:"IBaseComparerIntention",
            content:"IBaseComparerIntention",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare/IBaseComparerIntention',
            title:"IBaseComparerIntention",
            description:""
        }
    );
    a(
        {
            id:63,
            title:"EqualityComparerHelperRegistration",
            content:"EqualityComparerHelperRegistration",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare.Helper/EqualityComparerHelperRegistration_1',
            title:"EqualityComparerHelperRegistration<T>",
            description:""
        }
    );
    a(
        {
            id:64,
            title:"IocHandler",
            content:"IocHandler",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Initialization/IocHandler',
            title:"IocHandler",
            description:""
        }
    );
    a(
        {
            id:65,
            title:"IEqualityComparerHelperRegistration",
            content:"IEqualityComparerHelperRegistration",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare.Helper/IEqualityComparerHelperRegistration_1',
            title:"IEqualityComparerHelperRegistration<T>",
            description:""
        }
    );
    a(
        {
            id:66,
            title:"ICopyPostProcessing",
            content:"ICopyPostProcessing",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy.Processing/ICopyPostProcessing_1',
            title:"ICopyPostProcessing<TClassToCopy>",
            description:""
        }
    );
    a(
        {
            id:67,
            title:"IEqualityComparerHelperOperations",
            content:"IEqualityComparerHelperOperations",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Compare.Helper/IEqualityComparerHelperOperations_1',
            title:"IEqualityComparerHelperOperations<TModel>",
            description:""
        }
    );
    a(
        {
            id:68,
            title:"ICopyChildInterception",
            content:"ICopyChildInterception",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy/ICopyChildInterception_1',
            title:"ICopyChildInterception<TClassToCopy>",
            description:""
        }
    );
    a(
        {
            id:69,
            title:"ICopyStrategyProvider",
            content:"ICopyStrategyProvider",
            description:'',
            tags:''
        },
        {
            url:'/BBT.StructureTools/api/BBT.StructureTools.Copy.Strategy/ICopyStrategyProvider_2',
            title:"ICopyStrategyProvider<TStrategy, TCriterion>",
            description:""
        }
    );
    var idx = lunr(function() {
        this.field('title');
        this.field('content');
        this.field('description');
        this.field('tags');
        this.ref('id');
        this.use(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
        documents.forEach(function (doc) { this.add(doc) }, this)
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();