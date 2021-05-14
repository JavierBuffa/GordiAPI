export interface Team {
    id: number;
    teamName: string;
}

export const EmptyTeam = (): Team => ({
    id: null,
    teamName: null
});