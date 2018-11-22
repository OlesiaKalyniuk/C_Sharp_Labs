using System;
using System.Text;

namespace Lab1
{
    public class Magazine
    {
        private string _magazineName;
        private Frequency _timing;
        private DateTime _magazineDate;
        private int _magazineCirculation;
        private Article[] _article;

        public bool this[Frequency frequency]
        {
            get { return _timing == frequency; }
        }
        
        public Magazine():this("default Magazine", Frequency.Weekly, new DateTime(), 0, new Article[]{ })
        {
    
        }
        
        public Magazine(string magazineName, Frequency timing, DateTime magazineDate, int magazineCirculation, Article[] article)
        {
            _magazineName = magazineName;
            _timing = timing;
            _magazineDate = magazineDate;
            _magazineCirculation = magazineCirculation;
            _article = article;
        }

        public string MagazineName
        {
            get { return _magazineName; }
            set { _magazineName = value; }
        }

        public Frequency Timing
        {
            get { return _timing; }
            set { _timing = value; }
        }

        public DateTime MagazineDate
        {
            get { return _magazineDate; }
            set { _magazineDate = value; }
        }

        public Article[] Article
        {
            get { return _article; }
            set { _article = value; }
        }

        public double MiddleRate
        {
            get
            {
                double allRanges = 0;
                foreach (var article in Article)
                {
                    allRanges += article.ArticleRage;
                }
                return allRanges / Article.Length ;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            foreach (var article in Article)
            {
                stringBuilder.AppendLine(article.ToString());
            }
            return string.Format(" MagazineName: {0},\n Timing: {1},\n MagazineDate: {2},\n Article: {3},\n MiddleRate: {4}\n", MagazineName, Timing, MagazineDate, stringBuilder, MiddleRate);
        }

        public virtual string ToShortString()
        {
            return string.Format(" MagazineName: {0},\n Timing: {1},\n MagazineDate: {2},\n MiddleRate: {3}\n", MagazineName, Timing, MagazineDate, MiddleRate);
        }

        public void AddArticles(params Article[] articles)
        {
            Array.Resize(ref _article, Article.Length + articles.Length);
            Array.Copy(articles, 0, Article, Article.Length - articles.Length, articles.Length);
        }

        protected bool Equals(Magazine other)
        {
            return string.Equals(_magazineName, other._magazineName) && _timing == other._timing && _magazineDate.Equals(other._magazineDate) && _magazineCirculation == other._magazineCirculation && Equals(_article, other._article);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Magazine) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_magazineName != null ? _magazineName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) _timing;
                hashCode = (hashCode * 397) ^ _magazineDate.GetHashCode();
                hashCode = (hashCode * 397) ^ _magazineCirculation;
                hashCode = (hashCode * 397) ^ (_article != null ? _article.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Magazine left, Magazine right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Magazine left, Magazine right)
        {
            return !Equals(left, right);
        }
    }
}