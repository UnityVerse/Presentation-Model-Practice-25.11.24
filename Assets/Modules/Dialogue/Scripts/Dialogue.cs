using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class Dialogue
    {
        [ShowInInspector]
        public Sprite Icon
        {
            get { return this.config.icon; }
        }
        
        [ShowInInspector]
        public string CurrentMessage
        {
            get { return this.currentNode.content; }
        }

        [ShowInInspector]
        public string[] CurrentChoices
        {
            get { return this.currentNode.choices; }
        }

        [ShowInInspector]
        private readonly DialogueConfig config;

        private DialogueConfig.Node currentNode;

        public Dialogue(DialogueConfig config)
        {
            this.config = config;
            SetEntryNode();

        }

        private void SetEntryNode()
        {
            if (!this.config.FindEntryNode(out var node))
            {
                throw new Exception("Entry point is absent!");
            }

            this.currentNode = node;
        }

        public bool MoveNext(int choiceIndex)
        {
            if (this.config.FindNextNode(this.currentNode.id, choiceIndex, out var nextNode))
            {
                this.currentNode = nextNode;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            SetEntryNode();
        }
    }
}