using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace HoloTour.DataAcesss
{
    partial class DataSimulator
    {
        private List<PointOfInterestSimulatedData> GetpoiSimulatedData()
        {
            //Got dummy data from : itraveljerusalem http://www.itraveljerusalem.com/tour/ramparts-walk-southern-section/
            var ret = new List<PointOfInterestSimulatedData>()
            {
                new PointOfInterestSimulatedData()
                {
                    Title ="Old City Walls",
                    Position = new Position(35.22840200,31.77666300),
                    ImageBytes= "",
                    Text =@"The walls surrounding the Old City of Jerusalem were built in the
16th century at the command of the Ottoman ruler Sultan Suleiman
the Magnificent. For 400 years Turkish soldiers marched along the
path atop the city’s ramparts, patrolling between the gates and guard
towers. That path, which was recently renovated and turned into a
promenade, is a unique walking route that offers unusual views of
Jerusalem inside and outside the walls, looking at remnants from the
past and development in the present.
The British who conquered the Holy Land from the Turks in 1917 felt
a responsibility for preserving the city’s appearance and established
certain standards to help safeguard its special character. Among other
things, they decided that the undeveloped valleys surrounding the Old
City would remain so, to serve as a green belt that would separate
the old from the new. The British instituted regulations that prohibited
construction adjacent to or near the walls. This approach was also
adopted by Israeli planning authorities and is still in effect today.
Following the War of Independence and the capture of
the Old City by the Jordanian Arab Legion, the border
between Jordan and Israel was drawn close to the
wall. This border divided Jerusalem for a period of
19 years, until the Six Day War. Later on the Old City
Ramparts Walk was opened, as well as the Walls
Around Jerusalem National Park at the foot of the
walls.
There are two optional routes for the Ramparts Walk:
The northern route, from Jaffa Gate to the Lions Gate
(see the tour, “Upon Your Walls – Northern Section”)
and the southern route, which begins at the Tower
of David and ends at the Dung Gate. This pamphlet
describes the Southern Section of the Ramparts Walk."
                },
                new PointOfInterestSimulatedData()
                {
                    Title ="Jaffa Gate",
                    Position = new Position(35.22840200,31.77666300),
                    ImageBytes= "",
                    Text =@"The Jaffa Gate is named for the routes that once
led travelers to Jaffa in the west and Hebron in the
east. An Arabic inscription carved into the stone
above the gate blesses Allah and Sultan Suleiman
the Magnificent who built the gate and the wall in the
16th century. The inscription also refers to Abraham,
who resided in Hebron and is known in Arabic as
khalil Allah – a friend of God. This is why Jaffa Gate
is called Bab al-Khalil in Arabic.
The wall is pockmarked with bullet holes on either
side of the gate, and above the archway is a small
balcony, known as a “meshikuli” in Arabic, from the
English “machicolation,” a small balcony or turret through which it is possible to observe those entering
the city and if necessary – to pour boiling oil or tar
on your enemies. At the upper edge of the walls we
can see the crenellations that provided shelter for
the fighters who stood on the walls. The “L” shaped
defensive entryway is typical for many of the Old City’s
gates, which is aimed at making it more difficult for
invaders to gain access. Until 1875 the doors to the
gate were usually locked at sunset.
We enter through the Jaffa Gate. On the left are two
gravestones. Legend has it that these are the tombs
of the two engineers who built the wall for Sultan
Suleiman the Magnificent. According to one version
of the story, the Sultan beheaded them as soon as they
completed the construction work because they failed
to include Mt. Zion inside the city wall. According to
another version, the Sultan was quite pleased with
their work, but was afraid that they would go on to
construct similarly beautiful walls for other rulers, so
he had them executed."
                },new PointOfInterestSimulatedData()
                {
                    Title ="kishla",
                    Position = new Position(35.22840200,31.77666300),
                    ImageBytes= "",
                    Text =@"Let us look out onto the Old City. Here, beneath us,
stood the summer palace of Muhammad Ali, who
ruled the Holy Land from 1831-1840. Afterwards the
building was used by the Turkish army as a military
barracks, a “kishla” in Turkish. The British used the
kishla as a prison, as did the Jordanians. Since 1967
the building has been used by the Israel Police"
                },
                new PointOfInterestSimulatedData()
                {
                    Title ="The Tower of David",
                    Position = new Position(35.22840200,31.77666300),
                    ImageBytes= "",
                    Text =@"In front of us to the north is a minaret of the Ottoman
mosque mistakenly called the “Tower of David,”
a structure that has become one the most famous
symbols of Jerusalem. The mosque is part of a
fortress from the Middle Ages. However the original
structure is identified with King Herod, who built three
towers in this area that were named for three of his
loved ones: Miriam, his beloved wife, Hippicus, his
good friend, and Phasael, his brother. Only the base
of one of the towers, either Hippicus or Phasael,
survived. The upper part of the tower was built at
a later period, and from here we can clearly see the 
flags that are waving from the tower today.
The British conducted archaeological excavations
here and held art exhibits. During Jordanian rule
the Citadel was used as a military position. Today
it houses a museum that depicts the history of
Jerusalem, with a spectacular nighttime multimedia
presentation. "
                },
                new PointOfInterestSimulatedData()
                {
                    Title ="The Armenian Quarter",
                    Position = new Position(35.22840200,31.77666300),
                    ImageBytes= "",
                    Text =@"Adjacent to the wall is the building of the theological
seminary of the Armenian Patriarchate in Jerusalem.
Beyond it we can see the houses of the Armenian
Quarter and the dome of the Armenian St. James
Cathedral. The Armenian community originates from
Eastern Turkey, near Lake Van and Mt. Ararat. The
Armenians were the first to accept Christianity in 301,
and they are considered one of the oldest communities
in Jerusalem. The St. James Cathedral was built
during the Crusader Period. Following the Armenian
genocide during World War I, many refugees came to
Jerusalem and sought protection here. Since then the
monastery has become more of a residential quarter
Outside the walls we can see the red roofs of Yemin
Moshe. This neighborhood was constructed in 1892,
and it is named for Moses Montefiore. After the Six
Day War the houses here were restored and it became
a very elite neighborhood.
To the left of Yemin Moshe is the windmill that
Montefiore built in 1857, and beneath that, the
Mishkenot Sha’ananim quarter. This was the first
Jewish neighborhood to be built outside the walls
of the Old City in 1860, at the initiative of Moses
Montefiore and with the generosity of the wealthy
Jewish benefactor Judah Touro. Today the area is
used as the official guest house of the Jerusalem
Municipality for visiting artists and intellectuals.
Beneath the walls is the Hinnom Valley, mentioned in
the Bible as the accursed site where ancient idolatrous
Jews sacrificed their children to the god Molekh. The
prophets warned against these rites and forbade the
Jewish people from taking part. The valley is part of
the Walls Around Jerusalem National Park, as well
as the Jerusalem Trail that was recently opened for
hikers by the Nature and Parks Authority. You can
walk along the Hinnom Valley and enjoy its plentiful
trees and historical sites.
An ancient dam that was built in the Hinnom Valley
created an artificial pool in the northern portion of the
valley – this is The Sultan’s Pool, which is now used
as a venue for concerts and performances. It dates 
back to the Herodian Period and was refurbished in
the 14th century by the Mamalukes. It was further
improved by the Ottoman ruler Sultan Suleiman the
Magnificent, whose name it now bears.
To the south is Mt. Zion with its many historic and
religious sites. Adjacent to the wall is the Dormition
Abbey, with the conical dome. The church was
dedicated in 1910, and it marks the place where
the Virgin Mary, mother of Jesus, is believed to
have fallen asleep for the last time. The name of the
church comes from the Latin word dormitio, meaning
“sleep.”
Mt. Zion is sacred to the three monotheistic religious
and at its center is the Tomb of King David. Near
here is the site identified by Christian tradition as
the room of Jesus’ Last Supper. During the War of
Independence the hill was captured and after the
Old City fell to the Jordanians, Mt. Zion became a
pilgrimage site due to its proximity to the Western
Wall and the Temple Mount."
                },new PointOfInterestSimulatedData()
                {
                    Title ="View to the Mount of Olives",
                    Position = new Position(35.22840200,31.77666300),
                    ImageBytes= "",
                    Text =@"We are looking at the houses of the Jewish Quarter.
On May 28, 1948 the Jewish Quarter surrendered to
the soldiers of Jordan’s Arab Legion following a long
and difficult battle. Residents and defenders of the
Jewish Quarter left the city through the Zion Gate, and
19 years passed before they could return. After the
Six Day War and the reunification of Jerusalem, it was
decided to rebuild the Jewish Quarter from its ruins.
The most prominent building with the tall dome is the
Hurva Synagogue, which is undergoing renovations
and scheduled to be rededicated in 2010.
In the background towards the east is the Mount of
Olives with its various towers: The right hand tower
is part of the Russian Chapel of the Ascension, which
was built at the end of the 19th century. To the left
of that is the bell tower of the German August Victoria
Church, located on the hospital premises. The
leftmost tower is the tower of the Hebrew University
on Mt. Scopus, and around it we see the buildings
of the University and Hadassah Hospital Mt. Scopus
facility. On the southern part of the Mount of Olives
we can see Jerusalem’s ancient Jewish cemetery,
and on the lower slopes are houses in the Arab village
of Silwan. Across the valley from Silwan is the City
of David National Park, which features remains of
ancient Jerusalem from the First Temple Period and
later historical periods."
                },
                new PointOfInterestSimulatedData()
                {
                    Title ="Overview of the Temple Mount",
                    Position = new Position(35.22840200,31.77666300),
                    ImageBytes= "",
                    Text =@"Here, according to Jewish tradition, the world was
created and this is where Abraham came to sacrifice
Isaac. It is here that King Solomon built the First
Temple approximately 3,000 years ago, and where
the Returnees to Zion from Babylon built the Second
Temple. During the 1st century CE King Herod
renovated the Holy Temple and built the Temple Mount
Plaza we are familiar with today. The impressive plaza
is supported by four enormous support walls, one of
which is the Western Wall (the Kotel Ha-Ma’aravi).
The Second Temple was destroyed by the Romans in
70 CE, and the Temple Mount remained in ruins for
centuries until the Islamic conquest..
According to Islamic tradition Caliph Omar came to
the Temple Mount and found it covered in ashes.
Using his own robes Omar removed the ash from
the stone located in the center of the mountain and
exposed it. In 691 the ruler Abd al-Malik built the
Dome of the Rock with its renowned golden dome.
According to Islamic tradition, it is from here that the
prophet Muhammad ascended to heaven. Afterwards
the al-Aqsa Mosque was built by the Umayyad ruler
Caliph al-Walid.
The Dung Gate is mentioned in the Book of Nehemiah
as one of the city’s gates during the Return to Zion
(538 BCE). During that time the ashes and waste
from the Holy Temple was removed from the city
via the Dung Gate and was thrown into the Kidron
built himself a monument in the Valley of the King.
In reality, this is a tomb from the end of the Second
Temple Period built in Hellenistic style that indicates
the influence of foreign culture on Jerusalem’s Jews at
that time. The lower part of the tomb is carved into the
bedrock, and the upper part is built above that from
ashlar stones. This is a symbolic separation that
symbolizes the separation between the body buried in
the ground and the person’s soul. The tomb is meant
for the body, while the upper portion is referred to as
a nefesh (“soul”) – a Jewish funerary monument
similar to the Greek stele and is meant for the soul of
the departed.
In the past Jerusalem’s residents would bring their
rebellious sons to the site. They would throw stones at
the monument to remind their sons of the punishment
meted out to a rebellious a son – stoning."
                },
                new PointOfInterestSimulatedData()
                {
                    Title ="Kidron Valley",
                    Position = new Position(35.22840200,31.77666300),
                    ImageBytes= "",
                    Text =@"We are looking out towards the tombs of the Kidron
Valley, at the foot of the Mount of Olives. This
landscape is part of the Walls Around Jerusalem
National Park, along which we can see numerous
scenic, nature and Jewish heritage sites. The path
of the “Jerusalem Trail,” which was recently opened
for hikers by the National Nature and Parks Authority,
also follows the Kidron Valley.
The Kidron Valley was the eastern border of Jerusalem
for hundreds of years. During the First and Second
Temple Periods the city’s Jews would bury the dead
here, because Jewish law prohibited them from
burying people inside the city. Due to the area’s
proximity to the Holy Temple Jerusalem’s rich and
prominent residents would be buried here, and we are
standing in front of some impressive and exclusive
burial plots dating from the Second Temple Period."
                },



            };



            return ret;
        }
        class PointOfInterestSimulatedData
        {
            internal static PointOfInterestSimulatedData NullObject = new PointOfInterestSimulatedData()
            {
                Title = "Empty Title",
                Text = "No Text available",
                ImageBytes = @"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"
            };
            public string Title { get; set; }
            public string ImageBytes { get; set; }
            public string Text { get; set; }
            public Position Position { get; set; }
        }



    }
}
