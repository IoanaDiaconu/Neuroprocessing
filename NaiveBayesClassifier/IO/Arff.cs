using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaiveBayesClassifier.Training;

namespace NaiveBayesClassifier.IO
{
    public class Arff
    {
        public int SamplesCount { get; set; }
        public int AttributesCount { get; set; }
        public int TopicsCount { get; set; }
        public TrainingTuple [] TrainingTuples { get; set; }


    }
}
