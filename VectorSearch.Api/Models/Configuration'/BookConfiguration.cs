using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VectorSearch.Api.Data;

namespace VectorSearch.Api.Models.Configuration_;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name);

        builder.Property(e => e.Description);

        builder.Property(x => x.Embedding)
            .HasColumnType("vector(1536)");
        
        builder.HasIndex(x => x.Embedding)
            .HasMethod("hnsw")
            .HasOperators("vector_cosine_ops");
        
        builder.HasData( new List<Book>()
        {
            new Book
            {
                Id = Guid.Parse("e3e8e383-e69e-4c2d-94e6-d7e2a59d714d"),
                Name = "The Hobbit",
                Description = """
                              The Hobbit, written by J.R.R. Tolkien, follows Bilbo Baggins, a reluctant hobbit hero, as he joins a band of dwarves led by Thorin Oakenshield on a perilous quest to reclaim the Lonely Mountain and its treasure from the fearsome dragon Smaug, encountering trolls, goblins, elves, and the enigmatic Gollum, while discovering courage and cunning within himself, ultimately shaping the events that will unfold in the epic world of Middle-earth
                              """
            },
            new Book
            {
                Id = Guid.Parse("35cb9b12-85a8-46f4-86be-12e05778bef3"),
                Name = "The Lord of the Rings",
                Description = """
                              In J.R.R. Tolkien's 'The Lord of the Rings,' a young hobbit named Frodo Baggins embarks on a perilous journey with a diverse fellowship to destroy the One Ring and thwart the dark lord Sauron, facing battles, betrayals, and the complexities of Middle-earth, as alliances are forged, friendships tested, and destinies unfold in a sweeping epic that explores themes of power, sacrifice, and the enduring triumph of hope in the face of darkness.
                              """
            },
            new Book
            {
                Id = Guid.Parse("c4f49049-7731-4400-bcbd-afa977185c2b"),
                Name = "The Shining",
                Description = """
                              In Stephen King's 'The Shining,' the Torrance family—Jack, Wendy, and their psychic son Danny—takes on the winter caretaking of the haunted Overlook Hotel, where Jack's descent into madness, fueled by supernatural forces, threatens their lives and sanity; as Danny's psychic abilities intensify, the hotel's malevolent spirits come to life, and the family confronts a sinister past, culminating in a chilling battle between good and evil, exploring themes of isolation, addiction, and the eerie intersection of the supernatural with the vulnerabilities of the human psyche
                              """
            },
            new Book
            {
                Id = Guid.Parse("ed01fe5d-aff9-4f49-8b39-acc86e7bcef5"),
                Name = "The Iliad",
                Description = """
                              Homer's 'The Iliad' recounts the Trojan War's epic battles, centered around the wrath of Achilles, a Greek hero, delving into themes of honor, fate, and the human cost of war, as gods intervene and mortals grapple with mortality in a timeless narrative of heroism and tragedy
                              """
            },
            new Book
            {
                Id = Guid.Parse("6b406924-35df-452c-b306-1d91fc98fe81"),
                Name = "Mastering the Art of French Cooking",
                Description = """
                              Julia Child's 'Mastering the Art of French Cooking' is a culinary masterpiece, guiding aspiring chefs with meticulous detail through the intricacies of French cuisine, presenting a comprehensive blend of recipes, techniques, and anecdotes that demystify the culinary world and ignite a passion for the art of cooking, forever changing the landscape of American gastronomy
                              """
            }
        });
    }
}