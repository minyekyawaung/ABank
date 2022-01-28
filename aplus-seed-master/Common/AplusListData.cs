public class AplusListData<T>
    {
        public int total { get; set; }
        public int page {get;set;}
        public int pageSize {get;set;}
        public List<T>? rows{get;set;}
    }