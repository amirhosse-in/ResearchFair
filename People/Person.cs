using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    public class Person
    {
        public Person()
        {

        }
        public Person(int code,string name,string kind,string area,string value,string supervisor,string number,string sex)
        {
            this.کد = code;
            this.نام = name;
            this.نوع = kind;
            this.منطقه = area;
            this.تعداد = value;
            this.سرپرست = supervisor;
            this.شماره = number;
            this.جنسیت = sex;
        }
        public int کد { get; set; }
        public string نام { get; set; }
        public string نوع { get; set; }
        public string منطقه { get; set; }
        public string تعداد { get; set; }
        public string سرپرست { get; set; }
        public string شماره { get; set; }
        public string جنسیت { get; set; }
    }
}
