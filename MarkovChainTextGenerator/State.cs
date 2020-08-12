using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MarkovChainTextGenerator
{
    public class State
    {
        private static readonly Random Random = new Random();
        public string Key { get; }
        private ConcurrentDictionary<string, int> Connections { get; } = new ConcurrentDictionary<string, int>();

        public static State CreateInstance(string s)
        {
            return new State(s);
        }
        
        private State(string s)
        {
            Key = s;
        }

        public void Attach(string s, int occurence = 1)
        {
            Connections.AddOrUpdate(s, occurence, (key, previous) => previous + occurence);
        }

        public IDictionary<string, int> GetConnections()
        {
            return Connections;
        }

        public string GenerateMarkovOutput()
        {
            if (Connections.IsEmpty)
                return "";
            var u = Connections.Sum(p => p.Value);
            var r = Random.NextDouble() * u;
            double sum = 0;
            foreach(var (key, value) in Connections)
            {
                sum += value;
                if(r <= sum)
                    return key;
            }

            return null;
        }

        public void AddOccurrence(string key)
        {
            if (!Connections.TryGetValue(key, out var occurence))
            {
                Attach(key);
                return;
            }
            Connections.AddOrUpdate(key, occurence, (_, previous) => previous + 1);
        }

        public string GetFirstOutput()
        {
            var (key, value) = Connections.FirstOrDefault();
            return string.IsNullOrEmpty(key)
                ? ""
                : key;
        }
    }
}