using LazyGraphQl.Models;

namespace LazyGraphQl.Types;

public class BookType: ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Field(t => t.Id).Type<NonNullType<IdType>>();
            descriptor.Field(t => t.Title);
            descriptor.Field(t => t.Author);
        }
}
