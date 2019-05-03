using System;

namespace Blank
{
    /// <summary>
    /// http://www.sqlfiddle.com/#!18/e327a/4/0
    /// </summary>
    public class Sql
    {
        public void ProductsAndCategories()
        {
            var preQuery =
                @"
create table product
(
  product_id int identity not null primary key,
  name varchar(20),
  description varchar(50)
);

insert into product values
  ('Apple', 'Fruit'), 
  ('Banana', 'Fruit'),
  ('Watermelon', 'Berry');

create table category
(
  category_id int identity not null primary key,
  name varchar(50)
);

insert into category values('Cheap'), ('Comedy');


create table product_category_junction
(
  product_id int,
  category_id int,
  CONSTRAINT product_cat_pk PRIMARY KEY (product_id, category_id),
  CONSTRAINT FK_product FOREIGN KEY (product_id) REFERENCES product (product_id),
  CONSTRAINT FK_category FOREIGN KEY (category_id) REFERENCES category (category_id)
);

insert into product_category_junction
values (1, 1), (2, 2);";

            var query =
                @"
select p.name ProductName,
  c.name CategoryName
from product p
left join product_category_junction pc
  on p.product_id = pc.product_id
left join category c
  on pc.category_id = c.category_id";

        }
    }
}
