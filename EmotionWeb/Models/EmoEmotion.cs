﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmotionWeb.Models
{
    public class EmoEmotion
    {
        public int Id { get; set; }
        public float Score { get; set; } //Probabilidad de que emocion es
        public int EmoFaceId { get; set; }
        public EmoEmotionEnum EmotionType { get; set; }
        public virtual EmoFace Face { get; set; }
    }
}