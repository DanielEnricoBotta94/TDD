using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MarkovChainTextGenerator
{
    public class Manager
    {
        public ConcurrentDictionary<string, State> States { get; } = new ConcurrentDictionary<string, State>();
        private string Text { get; }
        
        public static Manager CreateInstance(string text)
        {
            var manager = new Manager(text);
            manager.CreateStates();
            return manager;
        }

        private void CreateStates()
        {
            var words = Text.Split();
            for (var i = 0; i < words.Length; i++)
            {
                var state = AddState(words[i]);
                if(i < words.Length - 1)
                    state.AddOccurrence(words[i + 1]);
            }
            
        }

        private Manager(string text)
        {
            Text = text;
        }

        public State AddState(string key)
        {
            if (States.TryGetValue(key, out var found))
                return found;   
            var state = State.CreateInstance(key);
            States.TryAdd(key, state);
            return state;
        }

        private State GetState(string key)
        {
            return States.TryGetValue(key, out var found) 
                ? found 
                : null;
        }

        public string GenerateOutput(string key)
        {
            var state = GetState(key);
            return state is null 
                ? "" 
                : state.GenerateMarkovOutput();
        }
        
        public string GenerateOutput()
        {
            var (_, value) = States.FirstOrDefault();
            return value is null 
                ? "" 
                : value.GetFirstOutput();
        }

        public string GetText()
        {
            return Text;
        }
    }
}