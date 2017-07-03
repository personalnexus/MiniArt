# MiniArt

The [Artwork](MiniArtLibrary/Artwork.cs) class defines a minimalist piece of art containing two lines and six shapes. By arranging them differently, different pieces of artwork can be created. Given such a defintion, the library can create an image from it.

![Sample artwork](MiniArtTest/TestData/Artwork.png)

Eventually, using different filters (i.e. implementations of [IArtworkFilter](MiniArtLibrary/Filters/IArtworkFilter.cs)) one can create vastly different images from the same input.

Future enhancements to this project include an automated upload to Instagram, so one may prepare several pieces of artwork and have them scheduled to upload at certain times.
