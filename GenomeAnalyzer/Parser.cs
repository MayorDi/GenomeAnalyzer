using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Net.NetworkInformation;

namespace GenomeAnalyzer;

/// <summary>
/// Parses an array of bytes and translates it into genome objects.
/// </summary>
public class Parser
{
    private readonly List<List<byte>> _data = new();

    public Parser(List<byte> bytes)
    {
        var arr = new List<byte>();

        for (int i = 0; i < bytes.Count; i++)
        {
            if (bytes[i] == 0x7A)
            {
                byte[] bts = {
                    bytes[i+4],
                    bytes[i+3],
                    bytes[i+2],
                    bytes[i+1],
                };
                int len = BitConverter.ToInt32(bts, 0);

                foreach (var j in Enumerable.Range(i + 4, len))
                {
                    arr.Add(bytes[j]);
                }

                i += 4 + len;
            }
        }

        arr.RemoveRange(0, 4);

        var bt = new List<byte>();
        for (var i = 0; i < arr.Count; i++)
        {
            var isVer = i + 3 < arr.Count ? Enumerable.SequenceEqual(
                new byte[] { arr[i], arr[i + 1], arr[i + 2], arr[i + 3] },
                new byte[] { 0x00, 0x00, 0x00, 0x5F }
            ) : false;

            if (isVer)
            {
                _data.Add(new List<byte>(bt));
                bt.Clear();

                i += 3;
            }
            else if (i == arr.Count - 1)
            {
                _data.Add(new List<byte>(bt));
                bt.Clear();
            }
            else
            {
                bt.Add(arr[i]);
            }
        }
    }

    /// <summary>
    /// Parses an array of bytes and returns the genome.
    /// </summary>
    /// <returns>A genome created from an array of bytes.</returns>
    public Genome Parsing()
    {
        Gene[] genes = new Gene[_data.Count-1];

        for (int i = 1; i < _data.Count; i++)
        {
            List<byte> bytes = _data[i];

            Color color = Color.FromArgb(
                (int)(BitConverter.ToSingle(new[] { bytes[3], bytes[2], bytes[1], bytes[0] }) * 255.0),
                (int)(BitConverter.ToSingle(new[] { bytes[7], bytes[6], bytes[5], bytes[4] }) * 255.0),
                (int)(BitConverter.ToSingle(new[] { bytes[11], bytes[10], bytes[9], bytes[8] }) * 255.0)
            );

            float splitMass = BitConverter.ToSingle(new[] { bytes[15], bytes[14], bytes[13], bytes[12] });
            float splitКRatio = BitConverter.ToSingle(new[] { bytes[19], bytes[18], bytes[17], bytes[16] });
            float splitAngle= BitConverter.ToSingle(new[] { bytes[23], bytes[22], bytes[21], bytes[20] });
            float ch1Angle = BitConverter.ToSingle(new[] { bytes[27], bytes[26], bytes[25], bytes[24] });
            float ch2Angle = BitConverter.ToSingle(new[] { bytes[31], bytes[30], bytes[29], bytes[28] });
            float nutPrio = BitConverter.ToSingle(new[] { bytes[35], bytes[34], bytes[33], bytes[32] });

            int ch1 = BitConverter.ToInt32(new[] { bytes[39], bytes[38], bytes[37], bytes[36] });
            int ch2 = BitConverter.ToInt32(new[] { bytes[43], bytes[42], bytes[41], bytes[40] });

            bool makeAd = BitConverter.ToBoolean(new[] { bytes[44] });
            bool keepA1 = BitConverter.ToBoolean(new[] { bytes[45] });
            bool keppA2 = BitConverter.ToBoolean(new[] { bytes[46] });

            int cellT = BitConverter.ToInt32(new[] { bytes[50], bytes[49], bytes[48], bytes[47] });
            
            // BitConverter.ToInt32(new[] { bytes[54], bytes[53], bytes[52], bytes[51] });
            
            bool prio = BitConverter.ToBoolean(new[] { bytes[55] });
            bool init = BitConverter.ToBoolean(new[] { bytes[56] });
            bool mirr1 = BitConverter.ToBoolean(new[] { bytes[57] });
            bool mirr2 = BitConverter.ToBoolean(new[] { bytes[58] });

            float adhS = BitConverter.ToSingle(new[] { bytes[62], bytes[61], bytes[60], bytes[59] });

            genes[i-1] = new(
                i-1,
                cellT,
                prio,
                init,
                makeAd,
                splitMass,
                splitКRatio,
                splitAngle,
                ch1Angle,
                ch2Angle,
                nutPrio,
                ch1,
                ch2,
                keepA1,
                keppA2,
                mirr1,
                mirr2,
                adhS,
                color,
                null
            );
        }

        return new Genome(genes);
    }
}