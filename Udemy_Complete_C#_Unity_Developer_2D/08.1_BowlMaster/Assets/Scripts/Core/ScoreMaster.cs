using System.Collections.Generic;
using System.Linq;

public class ScoreMaster {

    public static List<int> GetListOfFrameScores2(IEnumerable<int> bowlResults) {
        var result = new List<int>();

        var list = bowlResults.ToList();

        if (list.Count > 0) {
            var index = 0;
            while (index != -1) {
                index = RecursiveIteration(list, result, 0, index);
            }
        }
        return result;
    }

    public static List<int> GetListOfFrameScores(IEnumerable<int> bowlResults) {
        var result = new List<int>();
        var list = bowlResults.ToList();
        for (int i = 1; i < list.Count; i++) {
            if (result.Count == 10) break; // Eliminate Bonus frame in score

            // STRIKE or SPARE cases
            if (list[i - 1] == ActionMaster.MaxPins ||
                list[i - 1] != ActionMaster.MaxPins && list[i - 1] + list[i] == ActionMaster.MaxPins) {
                var sum = list[i - 1] + list[i];
                if (i + 1 < list.Count) {
                    sum += list[i + 1];
                    result.Add(sum);
                }
                if (list[i - 1] != ActionMaster.MaxPins) i++;
                continue;
            }
            // NORMAL frame case
            result.Add(list[i - 1] + list[i]);
            i++;
        }
        return result;
    }

    private static int RecursiveIteration(List<int> list, List<int> result, int addon, int index, int strikeNum = 0) {
        var current = list[index];
        if (result.Count == 10)
            return -1;
        if (strikeNum > 2) {
            result.Add(addon);
        }
        else if (index + 1 < list.Count) {
            if (current == ActionMaster.MaxPins) {
                RecursiveIteration(list, result, current + addon, index + 1, strikeNum + 1);
                return result.Count == 10 ? -1 : index + 1 ;
            }
            else {
                if (addon > 0 && strikeNum > 1) {
                    result.Add(current + addon);
                }
                else {
                    current += list[index + 1];
                    if (current == ActionMaster.MaxPins) {
                        if (index + 2 < list.Count)
                            RecursiveIteration(list, result, current + addon, index + 2, strikeNum + 2);
                        else if (result.Count == 9)
                            result.Add(current + addon);
                    }
                    else
                        result.Add(current + addon);
                    return index + 2 < list.Count ? index + 2 : -1;
                }
            }
        }
        else if (addon > 0 && strikeNum > 1) {
            result.Add(current + addon);
        }
        return -1;
    }

    public static List<int> GetCumulativeListOfFrameScores(IEnumerable<int> bowlResults) {
        var result = GetListOfFrameScores(bowlResults);
        for (int i = 1; i < result.Count; i++) {
            result[i] += result[i - 1];
        }
        return result;
    }
}
