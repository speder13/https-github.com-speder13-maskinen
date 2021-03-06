﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Accord;
using Accord.MachineLearning;


namespace Machinelearner
{
    public class Machine
    {
        ImageProperties properties;
        Accord.MachineLearning.Bayes.NaiveBayesLearning naiveBayes = new Accord.MachineLearning.Bayes.NaiveBayesLearning();
        Accord.MachineLearning.Bayes.NaiveBayes nb;
        public Machine()
        {
            properties = new Machinelearner.ImageProperties();
        }
        private int[][] _input; //image variables
        public int[][] trainerInput
        {
            get { return _input; }
            set { _input = value; }
        }
        private int[] _output; //class labels
        public int[] trainerOutput
        {
            get { return _output; }
            set { _output = value; }
        }
        
        public void train_model()
        {
            properties.load_ball_training();
            properties.load_empty_training();
            properties.load_error_training();
            nb = naiveBayes.Learn(properties.trainingInput, properties.trainingOutput);
        }
        public int decide(System.Drawing.Image image)
        {
            return (nb.Decide(properties.get_properties(image)));
        }
        
    }
}
