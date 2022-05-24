
import { atom } from "recoil";

// Key = unique ID (with respect to other atoms/selectors)
// Default = default value (aka initial value)

export const searchResultsState = atom({
    key: 'searchResultsState',
    default: {}
})